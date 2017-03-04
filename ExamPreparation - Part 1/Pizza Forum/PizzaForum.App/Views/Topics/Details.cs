using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Views.Topics
{
    public class Details : IRenderable<DetailsViewModel>
    {
        public string Render()
        {
            var detailsSb = new StringBuilder();

            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbarLogged = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navbarLogged = string.Format(navbarLogged, ViewBag.GetUserName());
            string details = File.ReadAllText(Constants.ContentPath + Constants.DetailsContent);

            detailsSb.Append(this.Model.TopicVM);

            foreach (var replyVM in this.Model.RepliesVM)
            {
                detailsSb.Append(replyVM);
            }

            details = string.Format(details, detailsSb);

            string replyDetails = File.ReadAllText(Constants.ContentPath + Constants.DetailsReplyContent);

            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbarLogged);
            sb.Append(details);
            sb.Append(replyDetails);
            sb.Append(footer);

            return sb.ToString();
        }

        public DetailsViewModel Model { get; set; }
    }
}
