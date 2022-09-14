using JobPortal.Data.Interfaces.Applicants;
using JobPortal.Data.Interfaces.Roles;
using JobPortal.Data.Repositories.Applicants;
using JobPortal.Data.Repositories.Roles;
using JobPortal.Service.Applicants;
using JobPortal.Service.Roles;
using Jobportel.Data;
using Jobportel.Data.Infrastructure;
using Jobportel.Data.Interfaces;
using Jobportel.Data.Repositories;
using Jobportel.Service.Users;
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

namespace Jobportel
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
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn")));
            services.AddControllers();
            services.AddScoped<IUserService, UserService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IApplicantRepository, ApplicantRepository>()
                .AddScoped<IApplicantService, ApplicantService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobPortal.Api", Version = "v1" });            
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobPortal.Api V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          
        }
    }
}
