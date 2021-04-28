using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HelperWPF.Interfaces;
using HelperWPF.Models;
using HelperWPF.Models.API;
using HelperWPF.Models.Rss;
using Newtonsoft.Json;

namespace HelperWPF.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private Rss _rss = null;
        public async Task<Item[]> GetNews()
        {
            if (_rss == null)
            {
                await Request();     
            }
            
            return _rss.Channel.Item.ToArray();
        }
        
        private async Task Request()
        {
            string newsUrl = "https://news.tut.by/rss/index.rss";

            using (var news = new HttpClient())
            {
                var newsXmlStream = await news.GetStreamAsync(newsUrl);
                XmlSerializer formatter = new XmlSerializer(typeof(Rss));
                _rss = (Rss) formatter.Deserialize(newsXmlStream);
            }
        }
    }
}