using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PizzaForum.Appp.BindingModels;
using PizzaForum.Appp.Data.Contracts;
using PizzaForum.Appp.Models;

namespace PizzaForum.Appp.Services
{
    public class ForumService : Service
    {

        public bool IsRegisterModelValid(RegisterUserBindingModel model)
        {
            if (model.Username.Length < 3)
                return false;

            var nameRegex = new Regex("^[a-z0-9]+$");
            if (!nameRegex.IsMatch(model.Username))
                return false;

            if (!model.Email.Contains("@"))
                return false;

            var passRegex = new Regex("^[0-9]{4}$");
            if (!passRegex.IsMatch(model.Password))
                return false;

            if (model.Password != model.ConfirmPassword)
                return false;

            if (this.Context.Users.Any(u => u.Username == model.Username || u.Email == model.Email))
                return false;

            return true;
        }

        public User GetUserFromModel(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = false
            };

            return user;
        }

        public void RegisterUser(User user)
        {
            if (this.Context.Users.Count() == 0)
            {
                user.IsAdmin = true;
            }

            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool IsLoginValid(LoginBindingModel model)
        {
            return this.Context.Users
                .Any(u =>
                    (u.Email == model.Credential || u.Username == model.Credential)
                    && u.Password == model.Password);
        }

        public User GetCorrespondingUser(LoginBindingModel model)
        {
            var user = this.Context.Users
                .FirstOrDefault(u =>
                    (u.Email == model.Credential || u.Username == model.Credential)
                    && u.Password == model.Password);
            return user;
        }

        public void LoginUser(User user, string sessionId)
        {
            var login = new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            };

            this.Context.Logins.Add(login);
            this.Context.SaveChanges();
        }
    }

}
