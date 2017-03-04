using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByTheCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContent = File.ReadAllText("../htdocs/index.html");
            Console.WriteLine(htmlContent);
        }
    }
}
