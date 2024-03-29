﻿using Microsoft.AspNetCore.Authorization;

// see https://chrissainty.com/securing-your-blazor-apps-configuring-policy-based-authorization-with-blazor/
namespace BlazorBoilerplate.Shared.AuthorizationDefinitions
{
    public static class Policies
    {
        public const string IsAdmin = "IsAdmin";
        public const string IsUser = "IsUser";
        public const string IsReadOnly = "IsReadOnly";
        public const string IsMyDomain = "IsMyDomain";

        public static AuthorizationPolicy IsAdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole("SuperAdmin", "Admin")
                .Build();
        }

        public static AuthorizationPolicy IsUserPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole("User")
                .Build();
        }

        public static AuthorizationPolicy IsReadOnlyPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("ReadOnly", "true")
                .Build();
        }

        public static AuthorizationPolicy IsMyDomainPolicy()
        {
            return new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .AddRequirements(new DomainRequirement("blazorboilerplate.com"))
            .Build();                
        }
    }
}
