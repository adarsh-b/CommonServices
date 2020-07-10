using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Net;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(CommonServices.API.Startup))]

namespace CommonServices.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var baseAddress = System.Configuration.ConfigurationManager.AppSettings.Get("AuthenticationAuthorityUrl");
            var clientId = System.Configuration.ConfigurationManager.AppSettings.Get("IdentityServerClientID");
            var clientSecret = System.Configuration.ConfigurationManager.AppSettings.Get("IdentityServerSecret");

            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s,
            X509Certificate certificate,
            X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = baseAddress,
                RequiredScopes = new[] { "email", "offline_access", "openid", "profile", "roles", "CommonServicesAPI" },
                ClientId = clientId,
                ClientSecret = clientSecret,
            });

            app.UseCors(CorsOptions.AllowAll);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration http = new HttpConfiguration();
            WebApiConfig.Register(http);
            app.UseWebApi(http);
        }
    }
}
