using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.WebSockets.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zero.Models;

namespace Zero.Authorization
{
    public class Jan20PayrollAdministratorsAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Jan20Payroll>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     Jan20Payroll resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }



            // Administrators can do anything.
            if (context.User.IsInRole(Constants.Jan20PayrollAdministratorsRole))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}