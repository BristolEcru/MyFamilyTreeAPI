namespace MagazynEdu.Authentication
{
    using System;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using MyFamilyTree.Domain.CQRS.Queries.QueryManagement;
    using MyFamilyTree.Domain.CQRS.Queries;
    using MyFamilyTree.Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNet.Identity;
    using MyFamilyTree.Domain.CQRS.Commands.CommandManagement;
    using MyFamilyTree.ApplicationServices.ModelsDto;

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
       
        private readonly IQueryExecutor queryExecutor;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
          
            IQueryExecutor queryExecutor)
            : base(options, logger, encoder, clock)
        {
        
            this.queryExecutor = queryExecutor;
        }

        // PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
        
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            User user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                var query = new GetUserQuery()
                {
                    Username = username
                };
                user = await this.queryExecutor.Execute(query);

                // TODO: HASH!
                if (user == null || user.PasswordHash != password)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}