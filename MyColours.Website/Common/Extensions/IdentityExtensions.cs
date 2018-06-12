using System.Security.Claims;
using System.Security.Principal;

namespace MyColours.Website.Common.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Name");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}