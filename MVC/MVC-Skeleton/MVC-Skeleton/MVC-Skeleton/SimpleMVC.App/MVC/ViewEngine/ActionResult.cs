using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable) Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public IRenderable Action { get; set; }
    }
}
