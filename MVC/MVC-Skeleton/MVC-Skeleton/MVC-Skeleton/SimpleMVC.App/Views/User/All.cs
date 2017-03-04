using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.User
{
    public class All : IRenderable<IEnumerable<AllUsernamesViewModel>>
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<a href=\"../home/index\">&#60;Home</a>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var username in ((IRenderable<IEnumerable<AllUsernamesViewModel>>)this).Model)
            {
                sb.AppendLine($"<li><a href=\"../user/profile?id={username.UserId}\">{username.Usernames}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }

        IEnumerable<AllUsernamesViewModel> IRenderable<IEnumerable<AllUsernamesViewModel>>.Model { get; set; }
    }
}
