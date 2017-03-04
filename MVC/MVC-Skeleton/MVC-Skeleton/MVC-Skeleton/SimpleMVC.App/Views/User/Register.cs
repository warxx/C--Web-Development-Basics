using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.User
{
    public class Register : IRenderable
    {
        public string Render()
        {
            var br = new StringBuilder();
            br.AppendLine("<a href=\"../home/index\">&#60;Home</a>");
            br.AppendLine("<h3>Register new user</h3>");
            br.AppendLine("<form action=\"register\" method=\"POST\"><br/>");
            br.AppendLine("Username: <input type=\"text\" name=\"Username\"/><br/>");
            br.AppendLine("Password: <input type=\"password\" name=\"Password\"/><br/>");
            br.AppendLine("<input type=\"submit\" value=\"Register\"/>");
            br.AppendLine("</form><br/>");
            return br.ToString();
        }
    }
}
