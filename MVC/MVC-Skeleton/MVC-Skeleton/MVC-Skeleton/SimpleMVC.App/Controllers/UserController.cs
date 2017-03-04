using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (var context = new NotesAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        public IActionResult<IEnumerable<AllUsernamesViewModel>> All()
        {
            List<User> users = null;
            using (var context = new NotesAppContext())
            {
                users = context.Users.ToList();
            }

            var viewModel = new List<AllUsernamesViewModel>();
            foreach (var user in users)
            {
                viewModel.Add(new AllUsernamesViewModel()
                {
                    Usernames = user.Username,
                    UserId = user.Id
                });
            }

            return this.View(viewModel.AsEnumerable());
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel()
                {
                    UserId = id,
                    Username = user.Username,
                    Notes = user.Notes
                        .Select(x =>
                                new NoteViewModel()
                                {
                                    Title = x.Title,
                                    Content = x.Content
                                }
                        )
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content,
                    Owner = user
                };

                context.Notes.Add(note);
                context.SaveChanges();
            }

            return Profile(model.UserId);
        }

        [HttpGet]
        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Login(LoginUserBindingModel model, HttpSession session)
        //{
        //    
        //}
    }
}
