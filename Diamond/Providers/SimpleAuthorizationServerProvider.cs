using Diamond.Business.Business;
using Diamond.Domain.DTO;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

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

            UsuarioDTO user = auth.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return; 
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("perfis", user.PerfisToJson()));

            context.Validated(identity);
        }
    }
}