using hr_system.Repository;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace hr_system.Providers
{
    public class AuthServiceProvider : OAuthAuthorizationServerProvider
    {
        private readonly ILoginService _loginService;

        public AuthServiceProvider(
            ILoginService loginService
            )
        {
            _loginService = loginService;
        }

        // validating the client
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // validating the user credintials
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if(_loginService.CanLogin(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Email, context.UserName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Invalid username or password");
            }
            return Task.FromResult(0);
        }
    }
}