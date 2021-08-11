using System.IO;
using System.Xml.Serialization;
using HelperWPF.Models;

namespace HelperWPF.Services
{
    public class AppService
    {
        private InfoAboutCurrentStateApp _info;
        private string _nameOfTheConfigurationFile = "conf.xml";

        public Location Location => _info.Location;

        public string UrlNews => _info.NewsInfo.Url;

        public AppService()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(InfoAboutCurrentStateApp));

            try
            {
                using (FileStream fs = new FileStream(this._nameOfTheConfigurationFile, FileMode.Open))
                {
                    this._info = (InfoAboutCurrentStateApp)formatter.Deserialize(fs);
                }
            }
            catch
            {
                this._info = new InfoAboutCurrentStateApp();
                this._info.Location = new Location { Lat = 53.893, Lon = 27.5674 };
                this._info.NewsInfo = new NewsInfo { Url = "https://www.onliner.by/feed" };
            }
        }

        public void SaveConfiguration()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(InfoAboutCurrentStateApp));

            using (FileStream fs = new FileStream(this._nameOfTheConfigurationFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this._info);
            }
        }
    }
}