﻿using Microsoft.AspNetCore.Authorization;
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
    public class Dec20PayrollAdministratorsAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Dec20Payroll>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                      Dec20Payroll resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.Dec20PayrollAdministratorsRole))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}