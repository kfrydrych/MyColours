using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyColours.Website.Models;
using MyColours.Website.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyColours.Website.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}