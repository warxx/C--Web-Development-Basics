using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.BindingModels;
using PizzaForum.Appp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Views.Categories
{
    public class Edit : IRenderable<EditCategoryViewModel>
    {
        
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbarLogged = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            string categoryEdit = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryEdit);
            categoryEdit = string.Format(categoryEdit, this.Model);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbarLogged);
            sb.Append(categoryEdit);
            sb.Append(footer);

            return sb.ToString();
        }

        public EditCategoryViewModel Model { get; set; }
    }
}
