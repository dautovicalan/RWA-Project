using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace PublicSite.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserAddress(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Address");
            return (claim != null) ? claim.Value : string.Empty;
        }       
    }
}