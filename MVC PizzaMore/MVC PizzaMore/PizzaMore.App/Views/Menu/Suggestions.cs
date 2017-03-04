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
    public class Suggestions : IRenderable<PizzaViewModel>
    {
        public string Render()
        {
            string topContent = File.ReadAllText("../../content/yoursuggestions-top.html");
            string bottomContent = File.ReadAllText("../../content/yoursuggestions-bottom.html");

            var sb = new StringBuilder();
            sb.AppendLine(topContent);
            sb.Append($"<p class=\"navbar-text navbar-right\">Signed in as {Model.Email}</p>\r\n" +
                      "</ul>\r\n" +
                      "</div>\r\n" +
                      "</div>\r\n" +
                      "</nav>\r\n" +
                      "<div class=\"jumbotron\">\r\n" +
                      "<div class=\"container\">\r\n");

            foreach (var pizza in this.Model.Pizzas)
            {
                sb.Append("<div class=\"col-sm-4\">" +
                          "<div class=\"card-deck\">\r\n" +
                          "<div class=\"card\">\r\n" +
                          $"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\" height=\"150px\" alt=\"Card image cap\">\r\n" +
                          "<div class=\"card-block\">\r\n" +
                          $"<h4 class=\"card-title\">{pizza.Title}</h4>\r\n" +
                          $"<p class=\"card-text\"><a href=\"/menu/details?pizzaId={pizza.Id}\">Recipe</a></p>\r\n" +
                          $"<p class=\"card-text\">Up: {pizza.UpVotes}</p>\r\n" +
                          $"<p class=\"card-text\">Down: {pizza.DownVotes}</p>\r\n" +
                          $"<a class=\"btn btn-danger\" href=\"/menu/delete?pizzaId={pizza.Id}\">Delete</a>\r\n" +
                          "</form>\r\n" +
                          "</div>\r\n" +
                          "</div>\r\n" +
                          "</div>\r\n" +
                          "</div>\r\n");
            }

            sb.Append(bottomContent);
            return sb.ToString();
        }

        public PizzaViewModel Model { get; set; }
    }
}
