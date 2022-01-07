using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreOperation.WebApi.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.FileProviders;
using StoreOperation.WebApi.ActionFilters;
using StoreOperation.WebApi.Configuration.Environment;
using StoreOperation.WebApi.Data.Contexts;
using StoreOperation.WebApi.Middlewares;

namespace StoreOperation.WebApi
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
            var sqlServerConnectionString =
                EnvironmentService.StaticConfiguration["ConnectionStrings:SqlServerConnectionString"];

            services.AddDbContext<StoreOperationDbContext>(opt => opt.UseSqlServer(sqlServerConnectionString));

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper(typeof(Startup));

            #region extension_add_service

            services.RegisterServices();
            services.RegisterUtility();
            services.RegisterRepositories();

            #endregion

            services.AddCors(options =>
            {
                options
                    .AddPolicy("AllowMyOrigin", builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });


            services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelStateAttribute)); })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
                .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            services.AddCustomSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{ 
            //}
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CheckList.WebApi v1"));
           

            app.UseHttpsRedirection();
            
            
            // proje klosöründe bulunan klasör ve dosyaların erişime açılması
            // app.UseStaticFiles(new StaticFileOptions
            // {
            //     FileProvider = new PhysicalFileProvider(
            //         Path.Combine(env.ContentRootPath, "images")),
            //     RequestPath = "/images"
            // });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowMyOrigin");

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}