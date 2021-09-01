using MemberManagement.Services.Families;
<<<<<<< HEAD
using MemberManagement.Services.Groups;
=======
>>>>>>> 2652236bafecbe3bfa6c7e9d59769d0a8833df17
using MemberManagerment.Data.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagerment.API
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
            services.AddControllers()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MemberManagementContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("MemberManagementConnext")));
            services.AddTransient<IFamilySV, FamilySV>();
<<<<<<< HEAD
            services.AddTransient<IGroupSV, GroupSV>();

            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger MemberManagement", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
=======

            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger MemberManagement", Version = "v1" });
>>>>>>> 2652236bafecbe3bfa6c7e9d59769d0a8833df17

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
