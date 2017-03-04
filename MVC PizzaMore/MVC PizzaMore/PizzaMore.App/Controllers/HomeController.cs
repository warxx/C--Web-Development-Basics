using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Services;
using PizzaMore.App.Utillities;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(HttpSession session, HttpResponse response, HttpRequest request)
        {
            var user = AuthenticationManager.IsAuthenticated(session);
            if (user != null)
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Indexlogged(HttpSession session, HttpResponse response)
        {
            var user = AuthenticationManager.IsAuthenticated(session);
            if (user == null)
            {
                this.Redirect(response, "/users/signin");
            }

            return this.View();
        }


    }
}
