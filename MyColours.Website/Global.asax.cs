using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FluentValidation.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyColours.Website.App_Start;
using MyColours.Website.Common.MvcHelpers;
using MyColours.Website.Models;
using MyColours.Website.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyColours.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutofacConfig.Configure();

            // Had to install Microsoft.AspNet.WebApi.WebHost & Microsoft.AspNet.WebApi
            // Core installed by default
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // If decimal is working, remove this below + Decimal Model Binder
            //ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
