using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpRequest
    {
        public RequestMethod Method { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public Header Header { get; set; }

        public HttpRequest()
        {
            this.Header = new Header(HeaderType.HttpRequest);
        }

        public override string ToString()
        {
            return string.Format($"{this.Method} {this.Url} HTTP/1.0\r\n{this.Header}\r\n{this.Content}");
        }
    }
}
