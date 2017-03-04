using PizzaForum.Appp.BindingModels;
using PizzaForum.Appp.Services;
using PizzaForum.Appp.Utillities;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaForum.Appp.Controllers
{
    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            if (!service.IsRegisterModelValid(rubm))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }

            var user = service.GetUserFromModel(rubm);
            this.service.RegisterUser(user);

            this.Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel lbm, HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            if (!service.IsLoginValid(lbm))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = service.GetCorrespondingUser(lbm);
            this.service.LoginUser(user, session.Id);

            this.Redirect(response, "/home/topics");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            AuthenticationManager.Logout(response, session.Id);

            this.Redirect(response, "/home/topics");
            return null;
        }
    }
}
