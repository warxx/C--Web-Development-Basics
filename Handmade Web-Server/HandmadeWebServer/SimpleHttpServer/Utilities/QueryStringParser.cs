using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Utilities
{
    public class QueryStringParser
    {
        public static IDictionary<string, string> Parse(string queryString)
        {
            queryString = WebUtility.UrlDecode(queryString);
            var variables = new Dictionary<string, string>();

            string[] vars = queryString.Split('&');

            if (vars.Length == 0)
            {
                vars[0] = queryString;
            }

            foreach (var variable in vars)
            {
                string[] tokens = variable.Split('=');
                variables.Add(tokens[0], tokens[1]);
            }

            return variables;
        }
    }
}
