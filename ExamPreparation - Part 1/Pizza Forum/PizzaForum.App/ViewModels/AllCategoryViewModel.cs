using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.Models;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.ViewModels
{
    public class AllCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("<tr>\r\n\t\t\t\t" +
                      $"<td><a href=\"#\">{this.CategoryName}</a></td>\r\n\t\t\t\t" +
                      $"<td><a href=\"/categories/edit?id={this.Id}\" class=\"btn btn-primary\"/>Edit</a></td>\r\n\t\t\t\t" +
                      $"<td><a href=\"/categories/delete?id={this.Id}\" class=\"btn btn-danger\"/>Delete</a></td>\r\n\t\t\t" +
                      "</tr>");

            return sb.ToString();
        }
    }
}
