using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleMVC.App.Controllers;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Extensions;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Routers
{
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        private string[] controllerActionParams;
        private string[] controllerAction;

        private HttpResponse response;
        private HttpRequest request;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
            this.request = new HttpRequest();
            this.response = new HttpResponse();
        }

        public HttpResponse Handle(HttpRequest request)
        {
            this.ParseInput(request);

            var method = GetMethod();
            var controller = GetController();
            IInvocable result =
                (IInvocable) method
                    .Invoke(controller, this.methodParams);

            string content = result.Invoke();

            var response = new HttpResponse()
            {
                ContentAsUTF8 = content,
                StatusCode = ResponseStatusCode.Ok
            };

            this.ClearRequestParameters();
            return response;
        }


        public void ClearRequestParameters()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public void InitRequestMethod(HttpRequest request)
        {
            this.requestMethod = request.Method.ToString();
        }

        public void InitControllerName()
        {
            this.controllerName = this.controllerAction[this.controllerAction.Length - 2].ToUpperFirst() +
                                  MvcContext.Current.ControllersSuffix;
        }

        public void InitActionName()
        {
            this.actionName = this.controllerAction[this.controllerAction.Length - 1].ToUpperFirst();
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (var methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType = string.Format("{0}.{1}.{2}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ControllersFolder,
                this.controllerName);

            var controller = (Controller) Activator.CreateInstance(Type.GetType(controllerType));
            return controller;
        }

        public void ParseInput(HttpRequest request)
        {
            string uri = WebUtility.HtmlDecode(request.Url);
            string query = string.Empty;

            if (request.Url.Contains('?'))
            {
                query = request.Url.Split('?')[1];
            }

            this.controllerActionParams = uri.Split('?');
            this.controllerAction = controllerActionParams[0].Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            this.controllerActionParams = query.Split('&');

            //Retrieve GET Params
            if (this.controllerActionParams.Length >= 1)
            {
                foreach (var pair in controllerActionParams)
                {
                    if (pair.Contains('='))
                    {
                        string[] keyValue = pair.Split('=');
                        this.getParams.Add(keyValue[0], keyValue[1]);
                    }
                }
            }

            //Retrieve POST Params
            string postParameters = request.Content;
            if (postParameters != null)
            {
                postParameters = WebUtility.UrlDecode(postParameters);
                string[] pairs = postParameters.Split('&');
                foreach (var pair in pairs)
                {
                    var keyValue = pair.Split('=');
                    this.postParams.Add(keyValue[0], keyValue[1]);
                }
            }

            this.InitRequestMethod(request);
            this.InitControllerName();
            this.InitActionName();

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("No such method");
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;
            foreach (var param in parameters)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType
                        );
                    index++;
                }
                else if (param.ParameterType == typeof(HttpRequest))
                {
                    this.methodParams[index] = this.request;
                    index++;
                }
                else if (param.ParameterType == typeof(HttpSession))
                {
                    this.methodParams[index] = this.request.Session;
                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties
                        = bindingModelType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                postParams[property.Name],
                                property.PropertyType));
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType
                        );
                    index++;
                }
            }
        }
    }
}
