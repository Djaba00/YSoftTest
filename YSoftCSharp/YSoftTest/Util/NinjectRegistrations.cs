using Ninject.Modules;
using Ninject.Web.Common;
using YSoftTest.DataContext;
using YSoftTest.Services;

namespace YSoftTest.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductsService>().To<ProductsService>().InRequestScope();

            Bind<ApplicationContext>().ToSelf().InRequestScope();
        }
    }
}