using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.Services;
using PizzaForum.Appp.Utillities;
using PizzaForum.Appp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Appp.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }


        [HttpGet]
        public IActionResult<IEnumerable<TopicsViewModel>> Topics(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);

            var viewModel = service.GetTopicsViewModel();

            return this.View(viewModel);
        }
    }
}
