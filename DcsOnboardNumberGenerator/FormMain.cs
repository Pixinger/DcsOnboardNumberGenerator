using System;
using System.IO;
using System.Windows.Forms;

namespace DcsOnboardNumberGenerator
{
    public partial class FormMain : Form
    {
        private string _LastFilename = "";
        public FormMain()
        {
            this.InitializeComponent();

            this.LoadSettings();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.LoadSettings();
        }
        protected override void OnClosed(EventArgs e)
        {
            this.SaveSettings();
            base.OnClosed(e);
        }

        private void numFirst_ValueChanged(object sender, EventArgs e)
        {
            if (this.numLast.Value < this.numFirst.Value)
                this.numLast.Value = this.numFirst.Value;
        }
        private void numLast_ValueChanged(object sender, EventArgs e)
        {
            if (this.numLast.Value < this.numFirst.Value)
                this.numFirst.Value = this.numLast.Value;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.AddExtension = true;
                dlg.CheckPathExists = true;
                dlg.CheckPathExists = true;
                dlg.RestoreDirectory = true;
                dlg.Multiselect = true;
                dlg.Filter = $"DCS-Mission | *.miz";
                dlg.FilterIndex = 1;
                #region Try to get the best path PRESET
                if (string.IsNullOrWhiteSpace(this._LastFilename))
                {
                    var directoryInfo = GetSavedGamesDirectory();
                    if (directoryInfo.Exists)
                    {
                        dlg.InitialDirectory = directoryInfo.FullName;
                    }
                    else
                    {
                        // give up :-(
                    }
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(this._LastFilename);
                    if (fileInfo.Exists)
                    {
                        dlg.FileName = fileInfo.FullName;
                    }
                    else
                    {
                        if (fileInfo.Directory.Exists)
                        {
                            dlg.InitialDirectory = fileInfo.Directory.FullName;
                        }
                        else
                        {
                            var directoryInfo = GetSavedGamesDirectory();
                            if (directoryInfo.Exists)
                            {
                                dlg.InitialDirectory = directoryInfo.FullName;
                            }
                            else
                            {
                                // give up :-(
                            }
                        }
                    }
                }
                #endregion
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (var filename in dlg.FileNames)
                    {
                        var result = this.Generate(new FileInfo(filename));
                        switch (result)
                        {
                            case Mission.ProcessResults.Ok:
                                break;
                            case Mission.ProcessResults.LoadError:
                                MessageBox.Show(this, $"Unable to load mission: {filename}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case Mission.ProcessResults.SaveError:
                                MessageBox.Show(this, $"Unable to save converted mission: {filename}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case Mission.ProcessResults.OutOfNumbers:
                                MessageBox.Show(this, $"Number-Limit exceeded. Unable to convert mission: {filename}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show(this, $"Unable to convert mission: {filename}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                        this._LastFilename = filename;
                    }
                }
            }
        }

        private void LoadSettings()
        {
            var config = ConfigXml.Load(ConfigXml.Filename);
            try { this.numFirst.Value = config.FirstNumber; } catch { }
            try { this.numLast.Value = config.LastNumber; } catch { }
            try { this._LastFilename = string.IsNullOrWhiteSpace(config.LastMission) ? "" : config.LastMission; } catch { }
            try
            {
                if (config.PositionX != -1 && config.PositionY != -1) this.Location = new System.Drawing.Point(config.PositionX, config.PositionY);
            }
            catch { }
        }
        private void SaveSettings()
        {
            var config = new ConfigXml();
            config.FirstNumber = (int)this.numFirst.Value;
            config.LastNumber = (int)this.numLast.Value;
            config.LastMission = string.IsNullOrWhiteSpace(this._LastFilename) ? "" : this._LastFilename;
            config.PositionX = this.Location.X;
            config.PositionY = this.Location.Y;
            config.Save(ConfigXml.Filename);
        }
        private DirectoryInfo GetSavedGamesDirectory()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return new DirectoryInfo(Path.Combine(userProfile, "Saved Games"));
        }
        private Mission.ProcessResults Generate(FileInfo fileInfo)
        {
            var mission = Mission.LoadFromMiz(fileInfo);
            if (mission == null)
                return Mission.ProcessResults.LoadError;

            var result = mission.Process((int)this.numFirst.Value, (int)this.numLast.Value);
            if (result != Mission.ProcessResults.Ok)
                return result;

            if (!mission.SaveToMiz())
                return Mission.ProcessResults.SaveError;

            return Mission.ProcessResults.Ok;
        }
    }
}
