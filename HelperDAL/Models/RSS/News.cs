using System.Xml.Serialization;
using System.Collections.Generic;
   
namespace HelperDAL.Models.Rss
{
	[XmlRoot(ElementName="image")]
	public class Image {
		[XmlElement(ElementName="url")]
		public string Url { get; set; }
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="link")]
		public string Link { get; set; }
	}

	[XmlRoot(ElementName="link", Namespace="http://www.w3.org/2005/Atom")]
	public class Link {
		[XmlAttribute(AttributeName="href")]
		public string Href { get; set; }
		[XmlAttribute(AttributeName="rel")]
		public string Rel { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="author", Namespace="http://www.w3.org/2005/Atom")]
	public class Author {
		[XmlElement(ElementName="name", Namespace="http://www.w3.org/2005/Atom")]
		public string Name { get; set; }
		[XmlElement(ElementName="uri", Namespace="http://www.w3.org/2005/Atom")]
		public string Uri { get; set; }
	}

	[XmlRoot(ElementName="category")]
	public class Category {
		[XmlAttribute(AttributeName="domain")]
		public string Domain { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="enclosure")]
	public class Enclosure {
		[XmlAttribute(AttributeName="url")]
		public string Url { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName="length")]
		public string Length { get; set; }
	}

	[XmlRoot(ElementName="guid")]
	public class Guid {
		[XmlAttribute(AttributeName="isPermaLink")]
		public string IsPermaLink { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="content", Namespace="http://search.yahoo.com/mrss/")]
	public class Content {
		[XmlAttribute(AttributeName="url")]
		public string Url { get; set; }
		[XmlAttribute(AttributeName="type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName="medium")]
		public string Medium { get; set; }
		[XmlAttribute(AttributeName="height")]
		public string Height { get; set; }
		[XmlAttribute(AttributeName="width")]
		public string Width { get; set; }
		[XmlAttribute(AttributeName="fileSize")]
		public string FileSize { get; set; }
	}

	[XmlRoot(ElementName="item")]
	public class Item {
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="link")]
		public string Link2 { get; set; }
		[XmlElement(ElementName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="author", Namespace="http://www.w3.org/2005/Atom")]
		public List<Author> Author { get; set; }
		[XmlElement(ElementName="category")]
		public Category Category { get; set; }
		[XmlElement(ElementName="enclosure")]
		public Enclosure Enclosure { get; set; }
		[XmlElement(ElementName="guid")]
		public Guid Guid { get; set; }
		[XmlElement(ElementName="pubDate")]
		public string PubDate { get; set; }
		[XmlElement(ElementName="content", Namespace="http://search.yahoo.com/mrss/")]
		public List<Content> Content { get; set; }
	}

	[XmlRoot(ElementName="channel")]
	public class Channel {
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="link")]
		public List<string> Link { get; set; }
		[XmlElement(ElementName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="language")]
		public string Language { get; set; }
		[XmlElement(ElementName="image")]
		public Image Image { get; set; }
		[XmlElement(ElementName="pubDate")]
		public string PubDate { get; set; }
		[XmlElement(ElementName="lastBuildDate")]
		public string LastBuildDate { get; set; }
		[XmlElement(ElementName="ttl")]
		public string Ttl { get; set; }
		[XmlElement(ElementName="item")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName="rss")]
	public class Rss {
		[XmlElement(ElementName="channel")]
		public Channel Channel { get; set; }
		[XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName="atom", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Atom { get; set; }
		[XmlAttribute(AttributeName="media", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Media { get; set; }
	}

}
