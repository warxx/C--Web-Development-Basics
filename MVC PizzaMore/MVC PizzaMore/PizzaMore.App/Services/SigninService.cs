using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using SimpleHttpServer.Models;

namespace PizzaMore.App.Services
{
    public class SigninService : Service
    {
        public SigninService(PizzaMoreContext context) : base(context)
        {
        }

        public User GetCorrespondingUser(LoginBindingModel model)
        {
            var user = this.context.Users
                .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            return user;
        }

        public void AddLogin(User user, HttpSession session)
        {
            var login = new Login()
            {
                sessionId = session.Id,
                User = user,
                IsActive = true
            };

            this.context.Logins.Add(login);
            context.SaveChanges();
        }
    }
}
