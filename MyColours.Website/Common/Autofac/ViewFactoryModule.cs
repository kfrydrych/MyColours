using Autofac;
using CQRS.Core.Factories;
using System.Linq;

namespace MyColours.Website.Common.Autofac
{
    public class ViewFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IViewBuilder>())
                .AsImplementedInterfaces();
        }
    }
}