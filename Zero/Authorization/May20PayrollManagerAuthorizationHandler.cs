using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zero.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebSockets.Internal;

namespace Zero.Authorization
{
    public class May20PayrollManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, May20Payroll>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   May20Payroll resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }


            if (
                requirement.Name != Constants.ReadOperationName
                )
            {
                return Task.CompletedTask;
            }

            // Managers can approve or reject.
            if (context.User.IsInRole(Constants.May20PayrollManagersRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}