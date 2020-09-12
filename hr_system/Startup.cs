using System;
using System.Threading.Tasks;
using System.Web.Http;
using hr_system.Providers;
using hr_system.Repository;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(hr_system.Startup))]

namespace hr_system
{
    public class Startup
    {
        private readonly AuthServiceProvider _authServiceProvider;

        public Startup()
        {
            _authServiceProvider = new AuthServiceProvider(new LoginService(new EmployeeService(new Data.HrDbModel()), new Sha256Hasher()));
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = _authServiceProvider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
