using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelperBLL.Interfaces;
using HelperBLL.Models;
using HelperDAL.Interfaces;
using HelperDAL.Models;
using HelperDAL.Repositories;

namespace HelperBLL.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _data;

        public NewsService(string url)
        {
            _data = new NewsRepository(url);
            
        }

        public async Task<List<News>> GetAllNews()
        {
            return (await _data.GetNews()).Select(item => new News()
            {
                Description = item.Description,
                Link = item.Link2,
                Title = item.Title,
                PublishDate = DateTime.Parse(item.PubDate),
            }).ToList();
        }
    }
}