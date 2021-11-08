using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Builder;
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

namespace MemberManagement.Client
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

            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IImageApiClient, ImageApi>();
            services.AddTransient<IPostApiClient, PostApiClient>();
            services.AddTransient<ITopicApi, TopicApi>();
            IMvcBuilder builder = services.AddRazorPages();

            services.AddControllersWithViews();
            services.AddSession(op => {
                op.IdleTimeout = TimeSpan.FromMinutes(30);
            });
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
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Product Detail Vn",
                  pattern: "post/{id}", new
                  {
                      controller = "Post",
                      action = "Details"
                  });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HomeClient}/{action=Index}/{id?}");
                
            });
            
        }
    }
}
