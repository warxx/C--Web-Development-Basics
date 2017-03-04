using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.App.BindingModels
{
    public class AddProductBindingModel
    {
        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }
    }
}
