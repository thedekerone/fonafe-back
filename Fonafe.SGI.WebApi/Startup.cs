using Fonafe.SGI.Domain.Repository.Interface;
using Fonafe.SGI.Domain.Repository.Repository;
using Fonafe.SGI.Domain.Service.Inteface.Blog;
using Fonafe.SGI.Domain.Service.Inteface.Financial;
using Fonafe.SGI.Domain.Service.Service.BlogService;
using Fonafe.SGI.Domain.Service.Service.Financial;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fonafe.SGI.WebApi
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
     services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200") // Replace with the Angular app's URL
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });
            services.AddControllers();

            // Registra IBlogRequestRepository y su implementación concreta.
            services.AddScoped<IBlogRequestRepository, BlogRequestRepository>();

            // Registra IBlogRequestService y su implementación.
            services.AddScoped<IBlogRequestService, BlogRequestService>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddTransient<IFlujoCajaRequestService, FlujoCajaRequestService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fonafe.SGI.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("AllowSpecificOrigin");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fonafe.SGI.WebApi v1"));
            }

        app.UseCors("AllowSpecificOrigin");
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
