using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeamManager.Admin.Queries.Contracts.Teams;
using TeamManager.Admin.Queries.Teams;
using TeamManager.Admin.QueryDataService.Contracts.DataAccess.Teams.Get;
using TeamManager.Admin.QueryDataService.Dapper;
using TeamManager.Admin.QueryDataService.Dapper.DataAccess.Teams;
using TeamManager.Admin.TransactionalDataService.Contracts;
using TeamManager.Admin.TransactionalDataService.EntityFramework;
using TeamManager.Admin.UseCases.Contracts.Teams.Commands;
using TeamManager.Admin.UseCases.Teams.Commands;

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

            services.AddScoped<GetAllQueryDataAccess, GetAllQueryDataAccess>();
            services.AddScoped<IGetQueryDataAccess, GetQueryDataAccess>();

            var businessConnectionString = Configuration.GetConnectionString("BusinessDatabase");

            services.AddScoped<ITransactionalDataService, EntityFrameworkTransactionalDataService>(c =>
                new EntityFrameworkTransactionalDataService(businessConnectionString));
            
            services.AddScoped(c => new DapperQueryDataService(businessConnectionString));

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
