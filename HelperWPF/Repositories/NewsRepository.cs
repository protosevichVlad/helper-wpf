using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using HelperWPF.Interfaces;

namespace HelperWPF.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        public async Task<News> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            List<News> news = new List<News>();
            
            String URLString = "https://news.tut.by/rss/all.rss";
            var webClient = new WebClient();

            string result = webClient.DownloadString(URLString);

            XDocument document = XDocument.Parse(result);

            return (from descendant in document.Descendants("item")
                select new News()
                {
                    Description = descendant.Element("description")?.Value,
                    Title = descendant.Element("title")?.Value,
                    PublishDate = DateTime.Parse(descendant.Element("pubDate")?.Value)
                }).ToList();
        }
    }
}