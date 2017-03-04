using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEngine.Pages
{
    public class contacts : Page
    {
        public contacts(string htmlPath) 
            : base(htmlPath)
        {
        }

        public contacts() 
            : this("../../content/contacts.html")
        {
            this.AddStyleToHtml("bootstrap/css/bootstrap.min.css");
            this.AddStyleToHtml("../../content/css/abous.css");
        }
    }
}
