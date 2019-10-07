using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudExam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using CloudExam.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace CloudExam
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
          
            services.AddDbContext<CloudExamDbContext>(options =>
              options.UseSqlServer(
                  Configuration["Data:ConnectionString"])).BuildServiceProvider();
            services.AddMvc();

            services.ConfigureServicesDependencies();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CloudExam API",
                    Version = "v1",
                    Description = "CloudExam API is the backend of the app.",
                    Contact = new OpenApiContact
                    {
                        Name = "Hector Rodriguez",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/hluisnet"),
                    }
                });
            });
        }
       
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudExam API");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

        }
    }
}
