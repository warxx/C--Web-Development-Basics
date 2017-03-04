using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace proben
{
    class Program
    {
        static void Main(string[] args)
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Hello World",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>
                    {
                        return new HttpResponse()
                        {
                            ContentAsUTF8 = "<h3>Hello from HttpServer :)</h3>",
                            StatusCode = ResponseStatusCode.Ok
                        };
                    }
                }
            };

            var httpServer = new HttpServer(8081, routes);
            httpServer.Listen();
        }
    }
}
