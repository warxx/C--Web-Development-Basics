using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<h2>NotesApp</h2>");
            sb.AppendLine("<a href=\"../user/all\">All Users</a>");
            sb.AppendLine("<a href=\"../user/register\">Register User</a>");

            return sb.ToString();
        }
    }
}
