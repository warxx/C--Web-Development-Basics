using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Views.Home
{
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home-logged.html");
        }
    }
}
