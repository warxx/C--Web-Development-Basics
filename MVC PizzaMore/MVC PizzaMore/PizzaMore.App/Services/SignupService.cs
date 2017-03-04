using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;

namespace PizzaMore.App.Services
{
    public class SignupService : Service
    {
        public SignupService(PizzaMoreContext context) : base(context)
        {
        }

        public void AddUserFromBinding(SignupBindingModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                Password = model.Password
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
    }
}
