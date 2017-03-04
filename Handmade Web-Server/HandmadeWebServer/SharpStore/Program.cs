using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;

namespace SharpStore
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var httpServer = new HttpServer(8081, RoutesConfig.GetRoutes());
            httpServer.Listen();
        }
    }
}
