using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Views.Categories
{
    public class All : IRenderable<AllViewModel>
    {
        public string Render()
        {

            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbarLogged = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navbarLogged = string.Format(navbarLogged, ViewBag.GetUserName());
            string categoriesAll = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoriesAll);
            categoriesAll = string.Format(categoriesAll, this.Model);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbarLogged);
            sb.Append(categoriesAll);
            sb.Append(footer);

            return sb.ToString();
        }

        public AllViewModel Model { get; set; }
    }
}
