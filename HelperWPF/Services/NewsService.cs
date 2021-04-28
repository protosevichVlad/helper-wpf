using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelperWPF.Interfaces;
using HelperWPF.ViewModel;

namespace HelperWPF.Services
{
    public class NewsService
    {
        private readonly INewsRepository _data;

        public NewsService(INewsRepository data)
        {
            _data = data;
        }
        
        public async Task<List<NewsViewModel>> GetAllNews()
        {
            return (await _data.GetNews()).Select(item => new NewsViewModel()
            {
                Description = item.Description,
                Link = item.Link2,
                Title = item.Title,
                PublishDate = DateTime.Parse(item.PubDate),
            }).ToList();
        }
    }
}