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
    public class Mar20PayrollAdministratorsAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Mar20Payroll>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     Mar20Payroll resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }



            // Administrators can do anything.
            if (context.User.IsInRole(Constants.Mar20PayrollAdministratorsRole))
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}