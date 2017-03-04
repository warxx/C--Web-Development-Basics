﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer.Models;

namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IHandleable
    {
        HttpResponse Handle(HttpRequest request);

    }
}
