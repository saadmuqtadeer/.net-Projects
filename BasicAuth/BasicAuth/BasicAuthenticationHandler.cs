using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BasicAuth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) 
        {
            
        }

        protected override async  Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Checks Header Contains Authorization key or not 
            if (!Request.Headers.ContainsKey("Authorization")) return AuthenticateResult.Fail("UnAuthorized");

            //Checks Header Authorization string
            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader)) return AuthenticateResult.Fail("UnAuthorized");

            //checks Authorization is Basic Auth or not
            if(!authorizationHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase)) return AuthenticateResult.Fail("UnAuthorized");
            
            //Get token
            var token = authorizationHeader.Substring(6);
            var credentialAsString  = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialAsString.Split(":");

            //Checks Credentials contains only name & password
            if (credentials.Length != 2) return AuthenticateResult.Fail("UnAuthorized");

            var username = credentials[0];
            var password = credentials[1];

            //checks Credintials
            if (username == "saad" && password == "saad@123") {
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, username)
                };
                var identity  = new ClaimsIdentity(claims, "Basics");
                var claimsPrinciple = new ClaimsPrincipal(identity);
                Console.WriteLine(Scheme.Name);
                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrinciple, Scheme.Name));
            }

            return AuthenticateResult.Fail("UnAuthorized");
        }
    }
}
