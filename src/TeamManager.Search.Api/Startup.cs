using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamManager.Search.Queries.Contracts.Teams;
using TeamManager.Search.Queries.Teams;
using TeamManager.Search.QueryDataService.Contracts.Teams;
using TeamManager.Search.QueryDataService.CosmosDb;
using TeamManager.Search.QueryDataService.CosmosDb.Teams;

namespace TeamManager.Search.Api
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
            var searchConnectionString = Configuration.GetConnectionString("SearchDatabase");
            var searchDatabaseName = Configuration.GetSection("Settings")["SearchDatabaseName"];
            services.AddScoped(s => new CosmosDbService(searchConnectionString, searchDatabaseName));

            services.AddScoped<IGetTeamsQuery, GetTeamsQuery>();

            services.AddScoped<IGetTeamsQueryDataAccess, GetTeamsQueryDataAccess>();

            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
