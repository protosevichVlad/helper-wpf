using System;
using System.Xml.Serialization;

namespace HelperDAL.Models
{
    [Serializable]
    [XmlRoot(ElementName="newInfo")]
    public class NewsInfo
    {
        [XmlAttribute(AttributeName="url")]
        public string Url { get; set; }
    }
}