﻿using Diamond.Business;
using Diamond.Domain.DTO;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diamond.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if(!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            //context.OwinContext.Set<string>("as:clientAllowedOrigin", client.alo)

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UsuarioDTO user = new AuthenticationBusiness().FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return; 
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("userId", user.Id.ToString()));
            identity.AddClaim(new Claim("userName", user.Nome));
            identity.AddClaim(new Claim("isAdmin", user.IsAdmin.ToString()));

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "userName", user.Nome },
                { "isAdmin", user.Id.ToString() }
            });

            var ticket = new AuthenticationTicket(identity, props);

            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return base.TokenEndpoint(context);
        }
    }
}