using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Wild.Piccolo.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirement requirement)
        {
            // If user does not have a 'scope' claim from this issuer, do nothing.
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
            {
                return Task.CompletedTask;
            }

            // Get the scope claim and split it into an array
            var scopeClaim = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer);

            if (scopeClaim == null)
            {
                return Task.CompletedTask;
            }

            var scopes = scopeClaim.Value.Split(' ');

            // If any scope matches the required one, mark the requirement as succeeded
            if (scopes.Any(s => s == requirement.Scope))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
