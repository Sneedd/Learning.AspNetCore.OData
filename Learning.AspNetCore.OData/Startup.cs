using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.AspNetCore.OData
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
            services.AddDbContext<EntityDbContext>(options =>
            {
                string tempDb = @"C:\temp\world.db";
                options.UseSqlite($"DataSource={tempDb}");
                options.EnableSensitiveDataLogging();
            });
            services.AddOData();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute("countryRoute", "odata", this.CreateModel());
                endpoints.Select().Filter().OrderBy().Expand().Count();
            });
        }

        private IEdmModel CreateModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Learning.OData.Entities";
            builder.EntitySet<Continent>("Continent");
            builder.EntitySet<Country>("Country");
            builder.EntitySet<City>("City");
            return builder.GetEdmModel();
        }
    }
}
