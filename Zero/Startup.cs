using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zero.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Zero.Authorization;

namespace Zero
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSession();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

           

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })/*.AddRazorPagesOptions(options => {
                options.AllowMappingHeadRequestsToGetHandler = false;
            })*/
       .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // Authorization handlers.
            services.AddScoped<IAuthorizationHandler,
                           EmployeeIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  EmployeeAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  EmployeeManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Jan19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jan19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jan19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Feb19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Feb19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Feb19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Mar19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Mar19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Mar19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Apr19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Apr19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Apr19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           May19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  May19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  May19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                       Jun19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jun19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jun19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                       Jul19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jul19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jul19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Aug19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Aug19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Aug19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Sep19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Sep19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Sep19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Oct19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Oct19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Oct19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                               Nov19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Nov19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Nov19PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                               Dec19PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Dec19PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Dec19PayrollManagerAuthorizationHandler>();

            ///


            services.AddScoped<IAuthorizationHandler,
                           Jan20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jan20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jan20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Feb20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Feb20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Feb20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Mar20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Mar20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Mar20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Apr20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Apr20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Apr20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           May20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  May20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  May20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                       Jun20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jun20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jun20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                       Jul20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jul20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Jul20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Aug20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Aug20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Aug20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Sep20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Sep20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Sep20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                   Oct20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Oct20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Oct20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                               Nov20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Nov20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Nov20PayrollManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                                                               Dec20PayrollIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Dec20PayrollAdministratorsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler,
                                  Dec20PayrollManagerAuthorizationHandler>();



            ///

            services.AddScoped<IAuthorizationHandler,
                           PaymentInvoiceIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  PaymentInvoiceAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  PaymentInvoiceManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           ReceiptInvoiceIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ReceiptInvoiceAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ReceiptInvoiceManagerAuthorizationHandler>();


            services.AddScoped<IAuthorizationHandler,
                           BudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  BudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  BudgetManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           ExpenseBudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ExpenseBudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ExpenseBudgetManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           ContractBudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                 ContractBudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ContractBudgetManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Payroll19BudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  Payroll19BudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  Payroll19BudgetManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           Payroll20BudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  Payroll20BudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  Payroll20BudgetManagerAuthorizationHandler>();

            services.AddScoped<IAuthorizationHandler,
                           ReceivingBudgetIsOwnerAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ReceivingBudgetAdministratorsAuthorizationHandler>();

            services.AddSingleton<IAuthorizationHandler,
                                  ReceivingBudgetManagerAuthorizationHandler>();


        }






    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();

            
        }
    }
}
