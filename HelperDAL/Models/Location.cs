using System;
using System.Xml.Serialization;

namespace HelperDAL.Models
{
    [Serializable]
    [XmlRoot(ElementName="location")]
    public class Location
    {
        [XmlAttribute(AttributeName="lat")]
        public double Lat { get; set; }
        
        [XmlAttribute(AttributeName="lon")]
        public double Lon { get; set; }
    }
}