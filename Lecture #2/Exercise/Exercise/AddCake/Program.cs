using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContent = File.ReadAllText("../htdocs/addcake.html");
            Console.WriteLine(htmlContent);

            string postContent = Console.ReadLine();

            string[] values = postContent.Split('&');

            string cakeName = values[0].Split('=')[1];
            string price = values[1].Split('=')[1];

            Console.WriteLine(WebUtility.UrlDecode($"<p>name: {cakeName}<br>price: {price}</p>"));

            File.AppendAllText("database.csv", WebUtility.UrlDecode($"{cakeName},{price}") + Environment.NewLine);

        }
    }
}
