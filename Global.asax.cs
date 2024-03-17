using Autofac.Integration.Mvc;
using Autofac;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin.Security;
using Store.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace Store
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Регистрация IAuthenticationManager
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication)
                .As<IAuthenticationManager>()
                .InstancePerRequest();

            // Регистрация UserManager
            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>())
                .As<AppUserManager>()
                .InstancePerRequest();

            // Регистрация UserManager
            builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>())
                .As<AppRoleManager>()
                .InstancePerRequest();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
