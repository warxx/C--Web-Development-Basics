using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.Models;

namespace PizzaMore.App.ViewModels
{
    public class PizzaViewModel
    {
        public PizzaViewModel()
        {
            this.Pizzas = new List<Pizza>();
        }

        public string Email { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
