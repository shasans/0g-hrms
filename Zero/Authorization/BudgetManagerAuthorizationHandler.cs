﻿using Microsoft.AspNetCore.Authorization;
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
    public class BudgetManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Budget>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Budget resource)
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
            if (context.User.IsInRole(Constants.BudgetManagersRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}