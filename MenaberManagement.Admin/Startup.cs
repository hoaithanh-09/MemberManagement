/////*using MemberManagement.ViewModels.UserViewModels;
using MemberManagement.ViewModels.CommonSV;
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                    .AllowAnyHeader()));

            services.Configure<Tinh>(Configuration.GetSection("Tinh"));
            services.AddHttpClient();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Login/Index/";
                   options.AccessDeniedPath = "/Login/Forbidden/";
               });
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            services.AddSession(op => {
                op.IdleTimeout = TimeSpan.FromMinutes(30);
            });
           
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRoleAppApiClient, RoleAppApiClient>();
            services.AddTransient<IFamilyApiClient, FamilyApiClient>();
            services.AddTransient<IAddressApiClient, AddressApiCliet>();
            services.AddTransient<IContactApiClientcs, ContactApiClinet>();
            services.AddTransient<IGroupApiClient, GroupApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClientcs>();
            services.AddTransient<IMemberApiClient, MemberApiClient>();
            services.AddTransient<IImageApi, ImageApi>();
            services.AddTransient<IPostApi, PostApi>();
            services.AddTransient<IPostApiClient, PostApiClient>();
            services.AddTransient<ITopicApi, TopicApi>();
            services.AddTransient<IActivityApi, ActivityApi>();
            services.AddTransient<IFundApi, FundApi>();
            services.AddTransient<IStorageService, FileStorageService>();
            IMvcBuilder builder = services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

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
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HomeClient}/{action=Index}/{id?}");
            });

            
        }
    }
}
