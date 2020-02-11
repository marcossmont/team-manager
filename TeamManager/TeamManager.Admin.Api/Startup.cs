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
using TeamManager.Admin.QueryDataService.Contracts;
using TeamManager.Admin.QueryDataService.Dapper;
using TeamManager.Admin.TransactionalDataService.Contracts;
using TeamManager.Admin.TransactionalDataService.EntityFramework;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;
using TeamManager.Admin.UseCases.Contracts.Teams.Queries;
using TeamManager.Admin.UseCases.Teams.Commands;
using TeamManager.Admin.UseCases.Teams.Queries;

namespace TeamManager.Admin.Api
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
            services.AddScoped<ICreateCommandHandler, CreateCommandHandler>();
            services.AddScoped<IGetAllQuery, GetAllQuery>();
            services.AddScoped<IGetQuery, GetQuery>();

            var businessConnectionString = Configuration.GetConnectionString("BusinessDatabase");

            services.AddScoped<ITransactionalDataService, EntityFrameworkTransactionalDataService>(c =>
                new EntityFrameworkTransactionalDataService(businessConnectionString));
            services.AddScoped<IQueryDataService, DapperQueryDataService>(c =>
                new DapperQueryDataService(businessConnectionString));

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
