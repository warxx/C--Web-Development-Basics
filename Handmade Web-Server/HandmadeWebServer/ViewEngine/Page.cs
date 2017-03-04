using System.Collections.Generic;
using System.IO;
using System.Net.Cache;
using System.Text;
using SimpleHttpServer.Models;

namespace ViewEngine
{
    public abstract class Page
    {
        private StringBuilder htmlContent;
        private const string ThemePath = "../../content/css/{0}.css";

        public HttpRequest request { get; set; }

        public Page(string htmlPath)
        {
            this.htmlContent = new StringBuilder(File.ReadAllText(htmlPath));
        }

        public void AddStyleToHtml(string stylePath)
        {
            int insertionIndex = htmlContent.ToString().IndexOf("</head>");

            this.htmlContent = htmlContent.Insert(insertionIndex, $"<link href=\"{stylePath}\" rel=\"stylesheet\">");
        }

        public override string ToString()
        {
            if (this.request != null && this.request.Header.Cookies.Contains("theme"))
            {
                this.AddStyleToHtml(string.Format(ThemePath, this.request.Header.Cookies["theme"].Value));
            }

            return this.htmlContent.ToString();
        }
    }
}
