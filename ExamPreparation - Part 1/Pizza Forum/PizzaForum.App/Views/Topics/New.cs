using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Views.Topics
{
    public class New : IRenderable<IEnumerable<string>>
    {
        public string Render()
        {
            var categoriesSb = new StringBuilder();
            foreach (var categoryName in this.Model)
            {
                categoriesSb.Append($"<option value=\"{categoryName}\">{categoryName}</option>");
            }

            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbarLogged = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navbarLogged = string.Format(navbarLogged, ViewBag.GetUserName());
            string topicsNew = File.ReadAllText(Constants.ContentPath + Constants.TopicsNew);
            topicsNew = string.Format(topicsNew, categoriesSb);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbarLogged);
            sb.Append(topicsNew);
            sb.Append(footer);

            return sb.ToString();
        }

        public IEnumerable<string> Model { get; set; }
    }
}
