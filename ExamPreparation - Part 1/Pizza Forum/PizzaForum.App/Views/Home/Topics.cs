using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Views.Home
{
    public class Topics  : IRenderable<IEnumerable<TopicsViewModel>>
    {
        public string Render()
        {
            var topicsSB = new StringBuilder();

            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbar;
            string currentUser = ViewBag.GetUserName();

            if (currentUser != null)
            {
                navbar = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
                navbar = string.Format(navbar, currentUser);
                topicsSB.Append("<div class=\"container\">");
                topicsSB.Append("<a href=\"/topics/new\" class=\"btn btn-success\" style=\"margin-bottom: 20px\">New Topic</a>");
            }
            else
            {
                topicsSB.Append("<div class=\"container\">");
                navbar = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            }

            string topics = File.ReadAllText(Constants.ContentPath + Constants.TopicsTemp);



            foreach (var topic in Model)
            {
                topicsSB.Append(topic);
            }
            topicsSB.Append("</div>");

            topics = string.Format(topics, topicsSB);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbar);
            sb.Append(topics);
            sb.Append(footer);

            return sb.ToString();
        }

        public IEnumerable<TopicsViewModel> Model { get; set; }
    }
}
