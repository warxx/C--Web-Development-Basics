using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using PizzaMore.App.ViewModels;
using SimpleHttpServer.Models;

namespace PizzaMore.App.Services
{
    public class MenuService : Service
    {
        public MenuService(PizzaMoreContext context) : base(context)
        {
        }

        public void AddPizza(AddProductBindingModel model, User user)
        {
            var pizza = new Pizza()
            {
                Title = model.Title,
                Recipe = model.Recipe,
                ImageUrl = model.ImageUrl,
                User = user,
                UpVotes = 0,
                DownVotes = 0
            };

            this.context.Pizzas.Add(pizza);
            this.context.SaveChanges();
        }

        public PizzaViewModel GetAllPizzas(HttpSession session)
        {
            var pizzas = this.context.Pizzas.ToList();
            var viewModel = new PizzaViewModel();
            viewModel.Email = this.context.Logins.First(x => x.sessionId == session.Id).User.Email;

            foreach (var pizza in pizzas)
            {    
                viewModel.Pizzas.Add(pizza);
            }

            return viewModel;
        }

        public PizzaViewModel GetUserPizzas(HttpSession session)
        {
            var user = this.context.Logins.First(x => x.sessionId == session.Id).User;
            var pizzas = this.context.Pizzas.Where(x=>x.User.Id == user.Id).ToList();
            var viewModel = new PizzaViewModel();
            viewModel.Email = user.Email;

            foreach (var pizza in pizzas)
            {
                viewModel.Pizzas.Add(pizza);
            }

            return viewModel;
        }

        public void DeletePizza(int pizzaId)
        {
            var pizza = this.context.Pizzas.Find(pizzaId);
            this.context.Pizzas.Remove(pizza);
            this.context.SaveChanges();
        }

        public bool IsPizzaUrlCorrect(int pizzaId, HttpSession session)
        {
            var pizza = this.context.Pizzas.Find(pizzaId);
            var user = this.context.Logins.First(x => x.sessionId == session.Id).User;

            if (pizza.User.Id == user.Id)
            {
                return true;
            }

            return false;
        }

        public void AddVoteForPizza(VotePizzaBindingModel model)
        {
            var pizza = this.context.Pizzas.Find(model.PizzaId);

            if (model.PizzaVote == "Up")
            {
                pizza.UpVotes++;
            }
            else
            {
                pizza.DownVotes++;
            }

            this.context.SaveChanges();
        }

        public PizzaDetailsViewModel GetPizzaDetails(int pizzaId)
        {
            var pizza = this.context.Pizzas.Find(pizzaId);

            var viewModel = new PizzaDetailsViewModel()
            {
                Title = pizza.Title,
                Recipe = pizza.Recipe,
                ImageUrl = pizza.ImageUrl,
                UpVotes = pizza.UpVotes,
                DownVotes = pizza.DownVotes
            };

            return viewModel;
        }
    }
}
