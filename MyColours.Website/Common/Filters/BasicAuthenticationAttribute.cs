using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System;
using System.Text;
using System.Web.Mvc;
using MyColours.Website.Common.Security;
using System.Threading;
using System.Security.Principal;

namespace MyColours.Website.Common.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);            
            else
            {
                var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                var username = usernamePasswordArray[0];
                var password = usernamePasswordArray[1];

                var authenticator = DependencyResolver.Current.GetService<IWebApiAuthenticator>();

                authenticator.Authenticate(username, password);

                if (authenticator.IsClientAuthenticated)
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}