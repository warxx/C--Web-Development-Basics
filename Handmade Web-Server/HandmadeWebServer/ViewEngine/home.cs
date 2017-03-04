using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEngine
{
    public class home : Page
    {
        public home(string htmlPath) 
            : base(htmlPath)
        {
        }

        public home() 
            : this("../../content/home.html")
        {
            this.AddStyleToHtml("bootstrap/css/bootstrap.min.css");
            this.AddStyleToHtml("../../content/css/carousel.css");
        }
    }
}
