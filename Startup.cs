using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using grpahQL_initial.Data;
using grpahQL_initial.GraphQL;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace grpahQL_initial
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddEntityFrameworkSqlite().AddDbContext<ApiDbContext>();

            //services.AddEntityFrameworkSqlServer()
            //   .AddDbContext<ApiDbContext>(options =>
            //   {
            //       options.UseSqlServer(ConnectionStringHelper.GetConnectionString(configuration),
            //                             sqlServerOptionsAction: sqlOptions =>
            //                             {
            //                                 sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
            //                                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            //                             });
            //   });
            //    services.AddDbContext<ApiDbContext>(options =>
            //options.UseSqlite(
            //    //Configuration.GetConnectionString("DefaultConnection")
            //));

            //services.AddEntityFrameworkSqlite().AddDbContext<CountryContext>();
            services.AddGraphQLServer()
                        .AddQueryType<Query>()
                        .AddType<ListType>()
                        .AddProjections()
                        //.AddMutationType<Mutation>()
                        .AddFiltering()
                        .AddSorting();
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<ApiDbContext>(options =>
               {
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
               });

            

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Shipment Tracking HTTP API",
            //        Version = "v1",
            //        Description = "The Shipment Microservice CRUD microservice sample"
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //app.UseSwagger();
            //app.UseSwagger(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShipmentTracking.API v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
        }
    }

    
}
