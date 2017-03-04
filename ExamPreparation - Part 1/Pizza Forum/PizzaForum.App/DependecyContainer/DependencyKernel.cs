using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SimpleMVC;

namespace PizzaForum.Appp.DependecyContainer
{
    public class DependencyKernel
    {
        private static StandardKernel kernel;

        public static StandardKernel Kernel
        {
            get
            {
                if (kernel == null)
                {
                    kernel = new StandardKernel();
                    kernel.Load(MvcContext.Current.ApplicationAssembly);
                }

                return kernel;
            }
        }
    }
}
