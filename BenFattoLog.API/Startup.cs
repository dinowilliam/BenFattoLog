using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BenFattoLog.API {

    using BenFattoLog.API.Manipulators.Contracts;
    using BenFattoLog.Application;
    using BenFattoLog.Application.Contracts;
    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Services;
    using BenFattoLog.DAL.Services.Contracts;

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
                options.AddDefaultPolicy(
                    builder => {
                        builder.WithOrigins("*")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                    });
            });

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddDbContext<BenFattoLogQueriesContext>(options =>
              options.UseNpgsql(Configuration.GetConnectionString("ApiDatabase")));

            services.AddDbContext<BenFattoLogCommandsContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ApiDatabase")));

            services.AddScoped<ILogServiceCommands, LogServiceCommands>();
            services.AddScoped<ILogServiceQueries, LogServiceQueries>();
            services.AddScoped<ILogApplication, LogApplication>();
            services.AddScoped<ILogManipulator, LogManipulator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BenFattoLog API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
