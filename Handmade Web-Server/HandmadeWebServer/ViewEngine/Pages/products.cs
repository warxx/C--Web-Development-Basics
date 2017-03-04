using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.Data;
using SharpStore.Data.Models;

namespace ViewEngine.Pages
{
    public class products : Page
    {
        private IList<Knife> knives;

        public products(string htmlPath, IList<Knife> knives) : base(htmlPath)
        {
            this.knives = knives;
        }

        public products(IList<Knife> knives) 
            :this("../../content/products.html", knives)
        {
            this.knives = knives;
            this.AddStyleToHtml("bootstrap/css/bootstrap.min.css");
            this.AddStyleToHtml("../../content/css/abous.css");
        }

        public override string ToString()
        {
            StringBuilder knivesStr = new StringBuilder();
            foreach (var knife in knives)
            {
                knivesStr.Append( "<div class=\"card col-lg-4\">\n" +
                                  "<img class=\"card-img-top img-responsive\"" +
                                 $" src=\"{knife.Url}\"" +
                                  " alt=\"Card image cap\">\n" +
                                  "<div class=\"card-block\">\n" +
                                 $"<h2 class=\"card-title\">{knife.Name}</h2>\n" +
                                 $"<h4 class=\"card-text\">{knife.Price}$</h4>\n" +
                                  "<a href=\"#\" class=\"btn btn-primary\">Buy Now</a>\n" +
                                  "</div>\n" +
                                  "</div>");
            }

            return string.Format(base.ToString(), knivesStr);
        }
    }
}
