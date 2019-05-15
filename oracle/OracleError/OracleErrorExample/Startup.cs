using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OracleErrorExample.App;
using OracleErrorExample.Infra;

namespace OracleErrorExample
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<OracleConnectionModel>(Configuration.GetSection($"ConnectionStrings:ORACLE"));
            services.AddLabDbContext(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public static class CustomExt
    {
        public static IServiceCollection AddLabDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LabDbContext>((serviceProvider, options) =>
            {
                var oracleConnectionModel = serviceProvider.GetRequiredService<IOptionsMonitor<OracleConnectionModel>>().CurrentValue;
                var connectionString = $"User Id = {oracleConnectionModel.User};Password={oracleConnectionModel.Password};Data Source={oracleConnectionModel.DataSource}; ";
                options.UseOracle(connectionString);
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);
            return services;
        }
    }
}
