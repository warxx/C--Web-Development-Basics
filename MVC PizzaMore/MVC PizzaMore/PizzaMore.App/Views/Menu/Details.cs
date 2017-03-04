using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMore.App.Views.Menu
{
    public class Details : IRenderable<PizzaDetailsViewModel>
    {
        public string Render()
        {
            string content = File.ReadAllText("../../content/details.html");

            var sb = new StringBuilder();

            sb.AppendLine($"<h3>{Model.Title}</h3>");
            sb.AppendLine($"<img src=\"{Model.ImageUrl}\" width=\"200px\" height=\"150px\"/>");
            sb.AppendLine($"<p>{Model.Recipe}</p>");
            sb.AppendLine($"<p>Up: {Model.UpVotes}</p>");
            sb.AppendLine($"<p>Down: {Model.DownVotes}</p>");

            return string.Format(content, sb);
        }

        public PizzaDetailsViewModel Model { get; set; }
    }
}
