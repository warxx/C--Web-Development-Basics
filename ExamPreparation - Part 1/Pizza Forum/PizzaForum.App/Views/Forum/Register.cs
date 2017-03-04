using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace PizzaForum.Appp.Views.Forum
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navbar = File.ReadAllText(Constants.ContentPath + Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.ContentPath + Constants.Register);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            var sb = new StringBuilder();
            sb.Append(header);
            sb.Append(navbar);
            sb.Append(register);
            sb.Append(footer);

            return sb.ToString();
        }
    }
}
