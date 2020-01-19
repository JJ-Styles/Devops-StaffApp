﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StaffApp.Data;
using StaffApp.Web.Services;
using StaffApp.Web.Services.Accounts;
using StaffApp.Web.Services.Invoices;
using StaffApp.Web.Services.Orders;
using StaffApp.Web.Services.ProductRequests;
using StaffApp.Web.Services.Products;
using StaffApp.Web.Services.Reviews;

namespace StaffApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration,
                        IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<StaffDb>(options => options.UseSqlServer(
                Configuration.GetConnectionString("StoreConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            if (_env.IsDevelopment())
            {
                services.AddTransient<IOrdersService, FakeOrdersService>();
                services.AddTransient<IInvoicesService, FakeInvoicesService>();
                services.AddTransient<IAccountsService, FakeAccountsService>();
                services.AddTransient<IProductRequestsService, FakeProductRequestService>();
                services.AddTransient<IProductsService, FakeProductsService>();
                services.AddTransient<IReviewsService, FakeReviewsService>();
            }
            else
            {
                services.AddTransient<IOrdersService, OrdersService>();
                services.AddTransient<IInvoicesService, InvoicesService>();
                services.AddTransient<IAccountsService, AccountsService>();
                services.AddTransient<IProductRequestsService, ProductRequestService>();
                services.AddTransient<IProductsService, ProductsService>();
                services.AddTransient<IReviewsService, ReviewsService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
