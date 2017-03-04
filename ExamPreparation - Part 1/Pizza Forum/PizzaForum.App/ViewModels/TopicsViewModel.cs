using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.ViewModels
{
    public class TopicsViewModel
    {
        public int Id { get; set; }

        public string TopicTitle { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
        public int RepliesCount { get; set; }
        public DateTime? DateTime { get; set; }

        public override string ToString()
        {
            string temp = "<div class=\"thumbnail\">\r\n\t" +
                          $"<h4><strong><a href=\"/topics/details?id={this.Id}\">{this.TopicTitle}</a><strong> " +
                          $"<small><a href=\"#\">{this.CategoryName}</a></small></h4>\r\n\t" +
                          $"<p><a href=\"#\">{this.Author}</a> | Replies: {this.RepliesCount} | {this.DateTime}</p>\r\n" +
                          "</div>";

            return temp;
        }
    }
}
