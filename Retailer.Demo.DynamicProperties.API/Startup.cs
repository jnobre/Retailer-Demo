using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Retailer.Demo.DynamicProperties.API.Mappers;
using Retailer.Demo.DynamicProperties.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Retailer.Demo.DynamicProperties.API", Version = "v1" });
            });

            var mongoServer = Environment.GetEnvironmentVariable("MongoServer");
            var mongoPort = Environment.GetEnvironmentVariable("MongoPort");
            var mongoUser = Environment.GetEnvironmentVariable("MongoUser");
            var mongoPass = Environment.GetEnvironmentVariable("MongoPass");
            var mongoDB = Environment.GetEnvironmentVariable("MongoDB");
            var mongoAuthSource = Environment.GetEnvironmentVariable("MongoAuthSource");

            services.AddAutoMapper(typeof(AutoMappings));


            services.ResolveApplicationDependencies();
            services.ResolveDomainDependencies(mongoUser, mongoPass, mongoServer, mongoPort, mongoAuthSource, mongoDB);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Retailer.Demo.DynamicProperties.API v1"));
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
