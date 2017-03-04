using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrowseCakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContent = File.ReadAllText("../htdocs/search.html");
            Console.WriteLine(htmlContent);

            string getContet = Environment.GetEnvironmentVariable("QUERY_STRING");

            string searchWord = getContet.Split('=')[1];
            string[] cakes = File.ReadAllLines("database.csv");

            Console.WriteLine("<p>");
            foreach (var currentCake in cakes)
            {
                string name = currentCake.Split(',')[0];
                decimal price = decimal.Parse(currentCake.Split(',')[1]);

                if (name.ToLower().Contains(searchWord.ToLower()))
                {
                    Console.Write(WebUtility.UrlDecode($"{name} ${price}<br>"));
                }
                
            }

            Console.WriteLine("</p>");
        }
    }
}
