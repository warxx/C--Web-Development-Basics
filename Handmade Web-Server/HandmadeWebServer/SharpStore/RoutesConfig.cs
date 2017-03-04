using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using SharpStore.Services;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using ViewEngine;
using ViewEngine.Pages;

namespace SharpStore
{
    public class RoutesConfig
    {
        public static IList<Route> GetRoutes()
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Theme Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/.+?\\?theme=.+$",
                    Callable = (request) =>
                    {
                        int indexOfQuestion = request.Url.IndexOf('?');
                        var themeDict = QueryStringParser.Parse(request.Url.Substring(indexOfQuestion+1));
                        var htmlFileName = request.Url.Substring(1, indexOfQuestion - 1);
                        Type typeOfWantedPage = Assembly.GetAssembly(typeof(home))
                            .GetTypes()
                            .FirstOrDefault(
                                type =>
                                    type.Name.Contains(htmlFileName[0].ToString() +
                                                       htmlFileName.Substring(1)));
                        Page instance = (Page)Activator.CreateInstance(typeOfWantedPage);
                        instance.AddStyleToHtml($"../../content/css/{themeDict["theme"]}.css");

                        var responce = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = instance.ToString()
                        };
                        
                        responce.Header.Cookies.Add(new Cookie("theme", themeDict["theme"]));

                        return responce;
                    }
                },
                new Route()
                {
                    Name = "Home Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/home$",
                    Callable = (request) =>
                    {
                        Page page = new home();
                        page.request = request;
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = page.ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "AboutUs Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/about$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/about.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Contacts Directory",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/contacts$",
                    Callable = (request) =>
                    {
                        Page page = new contacts();
                        page.request = request;
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = page.ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Contacts Directory Post",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^/contacts$",
                    Callable = (request) =>
                    {
                        string queryString = request.Content;
                        var variables = QueryStringParser.Parse(queryString);
                        new MessageService().AddMessageFromPostVars(variables);
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = new contacts().ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Products Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/products.*$",
                    Callable = (request) =>
                    {
              
                        var service = new KnivesService();
                        var products = service.GetAllKnivesFromUrl(request.Url);
                        Page page = new products(products);
                        page.request = request;
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            ContentAsUTF8 = page.ToString()
                        };
                    }
                },
                new Route()
                {
                    Name = "Image",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = @"^/images/.+\.jpg",
                    Callable = (request) =>
                    {
                        var nameOfFile = request.Url.Substring(request.Url.LastIndexOf('/'));
                        var responce = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.Ok,
                            Content = File.ReadAllBytes($"../../content/images/{nameOfFile}")
                        };
                        responce.Header.ContentType = "image/jpeg";
                        responce.Header.ContentLength = responce.Content.Length.ToString();
                        return responce;
                    }
                },
                new Route()
                {
                    Name = "CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/content/css/.+.css$",
                    Callable = (request) =>
                    {
                        string cssFileName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText($"../../content/css/{cssFileName}")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap.min",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/css/bootstrap.min.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/css/bootstrap.min.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                }
            };

            return routes;
        }
    }
}
