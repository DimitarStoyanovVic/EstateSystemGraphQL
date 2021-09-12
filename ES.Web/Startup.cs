using System;

using ES.DAL;
using ES.GraphQL;
using ES.GraphQL.MutationInput;
using ES.GraphQL.Mutations;
using ES.GraphQL.Types;
using ES.Utils;

using GraphQL.Server;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ES.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            this.Configuration = configuration;
            this.DbConfiguration = configuration;
            this.HostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }

        public IConfiguration DbConfiguration { get; }

        public IHostEnvironment HostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ESDbContext>(opt => opt.UseSqlServer(this.DbConfiguration.GetConnectionString(ConfigConstants.ESTATE_SYSTEM_DB)));

            services.AddScoped<CoreSchema>();

            services.AddControllers();

            services.AddGraphQL(o =>
                    {
                        o.EnableMetrics = false;
                        o.UnhandledExceptionDelegate = context => Console.WriteLine(context.Exception);
                    })
                    .AddSystemTextJson()
                    .AddGraphTypes(ServiceLifetime.Scoped)
                    .AddDataLoader();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL<CoreSchema>();

            app.UseGraphQLPlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}