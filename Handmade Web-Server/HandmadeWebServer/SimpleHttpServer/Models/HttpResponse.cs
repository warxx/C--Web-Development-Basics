using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Enums;

namespace SimpleHttpServer.Models
{
    public class HttpResponse
    {
        public ResponseStatusCode StatusCode { get; set; }

        public string StatusMessage
        {
            get { return Enum.GetName(typeof(ResponseStatusCode), this.StatusCode); }
        }

        public byte[] Content { get; set; }

        public string ContentAsUTF8
        {
            set { this.Content = Encoding.UTF8.GetBytes(value); }
        }

        public Header Header { get; set; }

        public HttpResponse()
        {
            this.Header = new Header(HeaderType.HttpResponse);
            this.Content = new byte[] { };
        }

        public override string ToString()
        {
            return string.Format($"HTTP/1.0 {(int) this.StatusCode} {this.StatusMessage}\r\n{this.Header}");
        }
    }
}
