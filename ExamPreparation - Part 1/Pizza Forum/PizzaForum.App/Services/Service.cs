using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using PizzaForum.Appp.Data;
using PizzaForum.Appp.Data.Contracts;
using PizzaForum.Appp.DependecyContainer;

namespace PizzaForum.Appp.Services
{
    public abstract class Service
    {

        public Service()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        protected IUnitOfWork Context { get; }
    }
}
