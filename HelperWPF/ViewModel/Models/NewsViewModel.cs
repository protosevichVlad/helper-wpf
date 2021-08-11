using HelperWPF.Infrastructure.Commands;
using System;
using System.Windows.Input;

namespace HelperWPF.ViewModel.Models
{
    public class NewsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
    }
}