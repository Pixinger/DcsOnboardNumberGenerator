using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace DcsOnboardNumberGenerator
{
    internal class Mission
    {
        private FileInfo _FileInfo;
        private string _Content;

        #region public enum ProcessResults
        public enum ProcessResults
        {
            Ok,
            Error,
            OutOfNumbers,
            SaveError,
            LoadError,
        }
        #endregion
        #region private class ConvertProcess
        private class ConvertProcess
        {
            public int CurrentNumber;
            public int LastNumber;

            public ConvertProcess(int firstNumber, int lastNumber)
            {
                this.LastNumber = lastNumber;
                this.CurrentNumber = firstNumber;

            }
        }
        #endregion        
        #region public class OutOfNumbersException : ApplicationException
        [Serializable]
        public class OutOfNumbersException : ApplicationException
        {
            public OutOfNumbersException() { }
        }
        #endregion

        private Mission(FileInfo fileInfo, string content)
        {
            this._FileInfo = fileInfo;
            this._Content = content;
        }

        public static Mission LoadFromMiz(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                return null;

            string content;
            try
            {
                using (ZipArchive zip = ZipFile.Open(fileInfo.FullName, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry missionEntry = zip.GetEntry("mission");
                    if (missionEntry == null)
                        throw new ApplicationException("File contains no 'mission' entry.");

                    using (StreamReader streamWriter = new StreamReader(missionEntry.Open()))
                    {
                        content = streamWriter.ReadToEnd();
                    }
                }
            }
            catch // Be ready for the unexpected...
            {
                return null;
            }

            return new Mission(fileInfo, content);
        }
        public bool SaveToMiz()
        {
            try
            {
                // Create Backup if requested.
                if (!this._FileInfo.Exists)
                    return false;

                // Create Backup
                File.Copy(this._FileInfo.FullName, $"{this._FileInfo.FullName}.bck", true);

                // Open and modify.
                using (ZipArchive zip = ZipFile.Open(_FileInfo.FullName, ZipArchiveMode.Update))
                {
                    // Remove previous mission file
                    var previousMissionEntry = zip.GetEntry("mission");
                    if (previousMissionEntry != null)
                        previousMissionEntry.Delete();

                    // Add new mission file
                    var newMissionEntry = zip.CreateEntry("mission", CompressionLevel.Optimal);
                    using (StreamWriter streamWriter = new StreamWriter(newMissionEntry.Open()))
                    {
                        streamWriter.Write(this._Content);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public ProcessResults Process(int firstNumber, int lastNumber)
        {
            try
            {
                var process = new ConvertProcess(firstNumber, lastNumber);

                string pattern = @"(\[""onboard_num""\]\s=\s"")(\d\d\d)("")";
                var evaluator = new MatchEvaluator(m =>
                {
                    if (process.CurrentNumber > process.LastNumber)
                        throw new OutOfNumbersException();

                    string value = string.Format("{0:000}", process.CurrentNumber++);
                    return $"{m.Groups[1].Value}{value}{m.Groups[3].Value}";
                });

                string content = this._Content;
                content = Regex.Replace(content, pattern, evaluator);
                this._Content = content;
                return ProcessResults.Ok;
            }
            catch (OutOfNumbersException)
            {
                return ProcessResults.OutOfNumbers;
            }
            catch
            {
                return ProcessResults.Error;
            }
        }
    }
}
