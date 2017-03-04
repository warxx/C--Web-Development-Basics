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
    public class Index : IRenderable<PizzaViewModel>
    {
        public string Render()
        {
            string content = File.ReadAllText("../../content/menu.html");

            var sb = new StringBuilder();
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
                          "<form method=\"POST\">\r\n" +
                          "<div class=\"radio\"><label><input type = \"radio\" name=\"PizzaVote\" value=\"Up\">Up</label></div>\r\n" +
                          "<div class=\"radio\"><label><input type = \"radio\" name=\"PizzaVote\" value=\"Down\">Down</label></div>\r\n" +
                          $"<input type=\"hidden\" name=\"PizzaId\" value=\"{pizza.Id}\" />\r\n" +
                          "<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />\r\n" +
                          "</form>\r\n" +
                          "</div>\r\n" +
                          "</div>\r\n" +
                          "</div>\r\n" +
                          "</div>");
            }

            return string.Format(content, sb);
        }

        public PizzaViewModel Model { get; set; }
        
    }
}
