using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }


        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            var viewModel = this.service.GetAllCategories(session);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult New(NewCategoryBindingModel catModel, HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            this.service.AddNewCategoryFromBind(catModel);
            
            this.Redirect(response, "/categories/all");
            return null;
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit(int id, HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            var viewModel = service.GetEditCategoryViewModel(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryBindingModel ecbm, HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            this.service.EditCategoryName(ecbm);

            this.Redirect(response, "/categories/all");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(int id, HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            var user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user.IsAdmin == false)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            service.DeleteCategory(id);
            this.Redirect(response, "/categories/all");
            return null;
        }

    }
}
