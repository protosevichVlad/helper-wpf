using System;

namespace HelperWPF
{
    public class News
    {
        public DateTime PublishDate;
        public string Title;
        public string Description;
        public string Link;

        public News()
        {
        }

        public News(DateTime dateTime, string title, string description, string link)
        {
            PublishDate = dateTime;
            Title = title;
            Description = description;
            Link = link;
        }
        
    }
}