using System;
using System.Xml.Serialization;

namespace HelperWPF.ViewModel.Models
{
    [Serializable]
    [XmlRoot(ElementName="newInfo")]
    public class NewsInfo
    {
        [XmlAttribute(AttributeName="url")]
        public string Url { get; set; }
    }
}