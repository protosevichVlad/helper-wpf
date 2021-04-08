using System;

namespace HelperWPF
{
    public class News
    {
        public readonly DateTime DateTime;
        public readonly string Title;
        public readonly string Description;
        public readonly string Link;

        public News(DateTime dateTime, string title, string description, string link)
        {
            DateTime = dateTime;
            Title = title;
            Description = description;
            Link = link;
        }
    }
}