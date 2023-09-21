using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class TokenAuthorizationAttribute : Attribute, IAuthorizationFilter
{
    private const string expectedApiToken = "KnockKnock";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var apiToken = context.HttpContext.Request.Headers["api-token"].FirstOrDefault();

        if (apiToken == null || !apiToken.Equals(expectedApiToken))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}