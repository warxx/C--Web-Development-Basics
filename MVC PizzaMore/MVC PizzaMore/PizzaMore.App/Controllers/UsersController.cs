using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Services;
using PizzaMore.App.Utillities;
using PizzaMore.App.Views.Users;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Signup(HttpResponse response, HttpSession session)
        {
            var user = AuthenticationManager.IsAuthenticated(session);
            if (user != null)
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(SignupBindingModel model,
            HttpResponse response)
        {

            var service = new SignupService(Data.Data.Context);
            service.AddUserFromBinding(model);

            this.Redirect(response, "/home/indexlogged");
            return null;
        }

        [HttpGet]
        public IActionResult Signin(HttpSession session, HttpResponse response)
        {
            var user = AuthenticationManager.IsAuthenticated(session);
            if (user != null)
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(LoginBindingModel model, HttpResponse response, HttpSession session)
        {
            var service = new SigninService(Data.Data.Context);

            var user = service.GetCorrespondingUser(model);
            if (user == null)
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            service.AddLogin(user, session);

            this.Redirect(response, "/home/indexlogged");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            var user = AuthenticationManager.IsAuthenticated(session);
            if (user == null)
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            AuthenticationManager.Logout(session.Id, response);

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
