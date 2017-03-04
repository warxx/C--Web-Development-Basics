using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Appp.ViewModels
{
    public class AllViewModel
    {
        public IEnumerable<AllCategoryViewModel> Categories { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var category in Categories)
            {
                sb.Append(category);
            }

            return sb.ToString();
        }
    }
}
