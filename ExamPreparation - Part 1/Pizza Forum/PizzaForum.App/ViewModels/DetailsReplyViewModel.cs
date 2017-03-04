using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.ViewModels
{
    public class DetailsReplyViewModel
    {
        public string AuthorName { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(ImageUrl))
            {
                string tempWihtoutImage = "<div class=\"thumbnail reply\">\r\n\t" +
                                          $"<h5><strong><a href=\"#\">{this.AuthorName}</a><strong> {this.Date}</h5>\r\n\t" +
                                          $"<p>{this.Content}</p>\r\n" +
                                          "</div>\t\t";
                return tempWihtoutImage;
            }

            string tempWithImage = "<div class=\"thumbnail reply\">\r\n\t" +
                          $"<h5><strong><a href=\"#\">{this.AuthorName}</a><strong> {this.Date}</h5>\r\n\t" +
                          $"<p>{this.Content}</p>\r\n\t" +
                          $"<img src=\"{this.ImageUrl}\" style=\"width: 350px; height: 150px\" alt=\"picture\"/>\r\n" +
                          "</div>\t";

            return tempWithImage;
        }
    }
}
