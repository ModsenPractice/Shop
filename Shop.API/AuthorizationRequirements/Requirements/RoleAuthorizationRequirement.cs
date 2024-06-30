using Microsoft.AspNetCore.Authorization;

namespace Shop.API.AuthorizationRequirements.Requirements
{
    public class RoleAuthorizationRequirement(string requiredRole) :
        IAuthorizationRequirement
    {
        public string RequiredRole { get; } = requiredRole;
    }
}