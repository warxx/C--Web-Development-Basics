using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.BindingModels
{
    public class EditCategoryBindingModel
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
