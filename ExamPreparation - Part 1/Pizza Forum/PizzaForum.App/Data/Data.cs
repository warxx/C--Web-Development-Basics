using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.Data
{
    public class Data
    {
        private static PizzaForumContext context;

        public static PizzaForumContext Context => context ?? (context = new PizzaForumContext());
    }
}
