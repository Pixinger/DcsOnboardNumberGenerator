using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DcsOnboardNumberGenerator
{
    [Serializable]
    public class ConfigXml
    {
        public static FileInfo Filename {  get { return new FileInfo("DcsOnboardNumberGenerator.xml"); } }
        #region Load/Save
        public static ConfigXml Load(FileInfo fileInfo)
        {
            try
            {
                if (fileInfo == null)
                    throw new ApplicationException();
                if (!fileInfo.Exists)
                    throw new ApplicationException();

                ConfigXml cfg = null;
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigXml));
                using (TextReader reader = new StreamReader(fileInfo.FullName, System.Text.Encoding.Unicode))
                {
                    cfg = serializer.Deserialize(reader) as ConfigXml;
                    reader.Close();
                }

                if (cfg == null)
                    throw new ApplicationException();
                
                return cfg;
            }
            catch
            {
                var cfg = new ConfigXml();
                cfg.Save(fileInfo);
                return cfg;
            }
        }
        public void Save(FileInfo fileInfo)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigXml));
                using (StreamWriter streamWriter = new StreamWriter(fileInfo.FullName, false, System.Text.Encoding.Unicode))
                {
                    serializer.Serialize(streamWriter, this, null);
                    streamWriter.Close();
                }
            }
            catch
            {
            }
        }
        #endregion

        [XmlElement]
        public int PositionX = -1;
        [XmlElement]
        public int PositionY = -1;
        [XmlElement]
        public int FirstNumber = 900;
        [XmlElement]
        public int LastNumber = 999;
        [XmlElement]
        public string LastMission;
    }
}
