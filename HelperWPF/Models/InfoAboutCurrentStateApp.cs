using System;
using System.Xml.Serialization;

namespace HelperWPF.Models
{
    [Serializable]
    [XmlRoot(ElementName="configuration")]
    public class InfoAboutCurrentStateApp
    {
        [XmlElement(ElementName="location")]
        public Location Location { get; set; }

        [XmlElement(ElementName="newsInfo")]
        public NewsInfo NewsInfo { get; set; }
    }
}