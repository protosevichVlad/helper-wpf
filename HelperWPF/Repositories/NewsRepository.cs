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
        public string Url = "https://www.onliner.by/feed";
        private Rss _rss = null;

        public NewsRepository(string url)
        {
            this.Url = url;
        }
        
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
            using (var news = new HttpClient())
            {
                var newsXmlStream = await news.GetStreamAsync(this.Url);
                XmlSerializer formatter = new XmlSerializer(typeof(Rss));
                _rss = (Rss) formatter.Deserialize(newsXmlStream);
            }
        }
    }
}