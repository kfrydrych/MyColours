using Autofac;
using CQRS.Core.Factories;
using MyColours.Website.Common.Security;
using MyColours.Website.Core.Common;
using MyColours.Website.Persistance;

namespace MyColours.Website.Common.Autofac
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ViewFactory>().As<IViewFactory>().AsSelf();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsSelf();
            builder.RegisterType<WebConfigAuthenticator>().As<IWebApiAuthenticator>().AsSelf();
        }
    }
}