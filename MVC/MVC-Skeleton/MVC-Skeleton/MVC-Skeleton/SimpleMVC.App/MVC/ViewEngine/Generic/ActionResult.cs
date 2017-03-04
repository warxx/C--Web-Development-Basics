﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.App.MVC.Interfaces.Generic;

namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action = (IRenderable<T>) Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));
            this.Action.Model = model;

        }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public IRenderable<T> Action { get; set; }
    }
}
