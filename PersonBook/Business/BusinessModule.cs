using System;
using Ninject.Modules;

namespace PersonBook
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonService>().To<PersonService>();
        }
    }
}
