using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.App.Data
{
    public class Data
    {
        private static PizzaMoreContext context;

        public static PizzaMoreContext Context => context ?? (context = new PizzaMoreContext());
    }
}
