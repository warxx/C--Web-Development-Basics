using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace PizzaForum.Appp.Views.Categories
{
    public class New : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbarLogged = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            string categoryNew = File.ReadAllText(Constants.ContentPath + Constants.AdminCategoryNew);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbarLogged);
            sb.Append(categoryNew);
            sb.Append(footer);

            return sb.ToString();
        }
    }
}
