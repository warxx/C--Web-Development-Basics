using Ninject.Modules;
using SimpleMVC.App.Data;
using SimpleMVC.App.Data.Interfaces;

namespace SimpleMVC.App.DependencyContainer
{
    public class Binding : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
