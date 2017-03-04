using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            string temp =
                $"<input type=\"hidden\" hidden=\"hidden\" class=\"form-control\" value=\"{this.Id}\" name=\"categoryId\">\r\n\t\t\t" +
                $"<input name=\"name\" type=\"text\" class=\"form-control\" placeholder=\"{this.CategoryName}\"/>";

            return temp;
        }
    }
}
