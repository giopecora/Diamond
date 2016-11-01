using Diamond.Business.Business;
using Diamond.Domain.DTO;
using Diamond.Domain.DTO.Result;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Diamond.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            AuthenticationBusiness auth = new AuthenticationBusiness();

            Result<UsuarioDTO> userResult = auth.FindUser(context.UserName, context.Password);

            if (!userResult.Success)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return; 
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim("sub", context.UserName));

            context.Validated(identity);
        }
    }
}