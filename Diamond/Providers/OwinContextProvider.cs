using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace Diamond.Providers
{
    public class OwinContextProvider
    {
        private ClaimsPrincipal User;

        public OwinContextProvider()
        {
            GetClaimsPrincipal();
        }

        private void GetClaimsPrincipal()
        {
            if (HttpContext.Current != null)
            {
                IOwinContext owinContext = HttpContext.Current.GetOwinContext();

                if(owinContext != null && owinContext.Authentication != null && owinContext.Authentication.User != null)
                {
                    User = owinContext.Authentication.User;
                }
            }
        }

        public Claim TryGetClaim(string key)
        {
            if (User != null && User.Claims != null)
            {
                var claims = (ClaimsPrincipal)Thread.CurrentPrincipal;
                return User.Claims.FirstOrDefault(c => c.Type.Equals(key));
            }

            return null;
        }

        public string GetClaimValue(string key)
        {
            Claim claim = TryGetClaim(key);

            if (claim != null)
                return claim.Value;

            return "";
        }
    }
}