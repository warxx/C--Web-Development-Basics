using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;

namespace SimpleMVC.App.Views.User
{
    public class Login : IRenderable
    {
        public string Render()
        {
            var br = new StringBuilder();
            br.AppendLine("<a href=\"../home/index\">&#60;Home</a>");
            br.AppendLine("<h3>Login</h3>");
            br.AppendLine("<form action=\"register\" method=\"POST\"><br/>");
            br.AppendLine("Username: <input type=\"text\" name=\"Username\"/><br/>");
            br.AppendLine("Password: <input type=\"password\" name=\"Password\"/><br/>");
            br.AppendLine("<input type=\"submit\" value=\"Log In\"/>");
            br.AppendLine("</form><br/>");
            return br.ToString();
        }
    }
}
