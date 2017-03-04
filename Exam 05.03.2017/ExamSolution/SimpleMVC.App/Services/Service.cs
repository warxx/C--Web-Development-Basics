using Ninject;
using SimpleMVC.App.Data.Interfaces;
using SimpleMVC.App.DependencyContainer;

namespace SimpleMVC.App.Services
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
