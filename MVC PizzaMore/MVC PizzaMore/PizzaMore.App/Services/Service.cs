using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaMore.App.Data;

namespace PizzaMore.App.Services
{
    public abstract class Service
    {
        protected PizzaMoreContext context;

        public Service(PizzaMoreContext context)
        {
            this.context = context;
        }
    }
}
