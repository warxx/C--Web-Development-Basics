using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            string environmentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);

            if (environmentVariable != null)
            {
                string requestMethod = environmentVariable.ToLower();
                if (requestMethod == "post")
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsGet()
        {
            string environmentVariable = Environment.GetEnvironmentVariable(Constants.RequestMethod);

            if (environmentVariable != null)
            {
                string requestMethod = environmentVariable.ToLower();
                if (requestMethod == "get")
                {
                    return true;
                }
            }

            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.QueryString));

            return RetrieveRequestParamaeters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Console.ReadLine()));

            return RetrieveRequestParamaeters(parametersString);
        }

        public static IDictionary<string, string> RetrieveRequestParamaeters(string parametersString)
        {
            Dictionary<string, string> resultParameters = new Dictionary<string, string>();

            var parameters = parametersString.Split('&');

            foreach (var param in parameters)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;

                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.CookieGet));

            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();

            var cookieSaves = cookieString.Split(';');

            foreach (var cookieSave in cookieSaves)
            {
                var cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }

            return cookies;
        }
    }
}
