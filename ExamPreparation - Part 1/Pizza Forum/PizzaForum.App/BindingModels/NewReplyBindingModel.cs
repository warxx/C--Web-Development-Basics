using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.BindingModels
{
    public class NewReplyBindingModel
    {
        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
