using Learning.AspNetCore.OData.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Learning.AspNetCore.OData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EntityDbContext>(options =>
            {
                options.UseInMemoryDatabase("demo");
                //options.UseSqlite($"DataSource=C:\\temp\\world.db");
            });
            services.AddControllers()
                .AddOData(options =>
                {
                    options.AddRouteComponents("odata", this.CreateModel());
                    options.Select().Filter().OrderBy().Expand().Count();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseODataRouteDebug();
            }

            app.UseODataBatching();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IEdmModel CreateModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Learning.OData.Entities";
            builder.EntitySet<Continent>("Continents");
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<City>("Cities");
            return builder.GetEdmModel();
        }
    }
}
