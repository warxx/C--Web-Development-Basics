using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaForum.Appp.BindingModels;
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
    public class TopicsController : Controller
    {
        private TopicsService service;

        public TopicsController()
        {
            this.service = new TopicsService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> New(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            AuthenticationManager.GetAuthenticatedUser(session.Id);

            var categoryNames = service.GetCategoryNames();

            return this.View(categoryNames);
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response,
            NewTopicBindingModel ntbm)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            service.AddNewTopicFromBind(ntbm, user);

            this.Redirect(response, "/home/topics");
            return null;
        }

        [HttpGet]
        public IActionResult<DetailsViewModel> Details(int id, HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            AuthenticationManager.GetAuthenticatedUser(session.Id);

            var detailTopicViewModel = service.GetDetailTopicVM(id);
            var detailRepliesViewModel = service.GetDetailsRepliesVM(id);
            var detailsViewModel = new DetailsViewModel()
            {
                TopicVM = detailTopicViewModel,
                RepliesVM = detailRepliesViewModel
            };


            return this.View(detailsViewModel);
        }

        [HttpPost]
        public IActionResult Details(int id, HttpResponse response,
            HttpSession session, NewReplyBindingModel npbm)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            this.service.AddNewReply(id, user, npbm);

            this.Redirect(response, $"/topics/details?id={id}");
            return null;
        }
    }
}
