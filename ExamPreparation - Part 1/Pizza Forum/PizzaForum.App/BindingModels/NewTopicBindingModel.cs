using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.BindingModels
{
    public class NewTopicBindingModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}
