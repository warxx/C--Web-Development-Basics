using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.User
{
    public class Greet : IRenderable
    {
        public GreetViewModel Model { get; set; }

        public string Render()
        {
            return $"<p>Hello user with session id: {Model.SessionId}</p>";
        }
    }
}
