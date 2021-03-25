using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using LocalEntities;

namespace Project.ViewModel
{
    class NewsViewModel : BaseViewModel
    {
        public string NewsName
        {
            get => newsName;
            set
            {
                newsName = value;
                OnPropertyChanged(nameof(NewsName));
            }
        }
        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private string newsName;
        private string content;
        private DateTime date;

        public NewsViewModel()
        {
            List<News> news = new GetNewsModel().GetNews();
            
            NewsName = news.Last().NewsName;
            Content = news.Last().Content;
            date = news.Last().Date;
        }
    }
}
