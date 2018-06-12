using MyColours.Website.Common.Filters;
using System.Web.Http;

namespace MyColours.Website.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // This needs to be added to remove xml format from API
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // CamelCase Format setup
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //config.Filters.Add(new BasicAuthenticationAttribute());

        }
    }
}