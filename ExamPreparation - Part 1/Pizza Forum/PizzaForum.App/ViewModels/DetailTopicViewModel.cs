using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.ViewModels
{
    public class DetailTopicViewModel
    {
        public string TopicTitle { get; set; }

        public string AuthorName { get; set; }

        public DateTime? DateTime { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            string temp = "<div class=\"thumbnail\">\r\n\t\t" +
                          $"<h4><strong><a href=\"#\">{this.TopicTitle}</a><strong></h4>\r\n\t\t" +
                          $"<p><a href=\"#\">{this.AuthorName}</a> {this.DateTime}</p>\r\n\t\t" +
                          $"<p>{this.Content}</p>\r\n\t" +
                          "</div>";

            return temp;
        }
    }
}
