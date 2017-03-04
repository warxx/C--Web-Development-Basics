using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Models
{
    public class HttpSession
    {
        private IDictionary<string, string> parameteres;

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameteres = new Dictionary<string, string>();
        }

        public string Id { get; set; }

        public string this[string key]
        {
            get { return this.parameteres[key]; }
            set
            {
                this.Add(key, value);
            }
        }

        public void Clear()
        {
            this.parameteres.Clear();
        }

        public void Add(string key, string value)
        {
            this.parameteres.Add(key, value);
        }
    }
}
