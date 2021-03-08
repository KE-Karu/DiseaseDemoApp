using DiseasesDemoApp.InputTypes;
using DiseasesDemoApp.Mutations;
using DiseasesDemoApp.Repositories;
using DiseasesDemoApp.Schemas;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DiseasesDemoApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DiseasesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IPersonalDiseasesRepository, PersonalDiseasesRepository>();
            services
                .AddScoped<PersonsDiseaseSchema>()
                .AddScoped<PersonsDiseaseMutation>()
                .AddScoped<PersonsInputType>()
                .AddScoped<DiseaseInputType>()
                .AddScoped<PersonalDiseaseInputType>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })


            // Add required services for GraphQL request/response de/serialization
                .AddSystemTextJson() // For .NET Core 3+
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader() // Add required services for DataLoader support
                .AddGraphTypes(typeof(PersonsDiseaseSchema), ServiceLifetime.Scoped); // Add all IGraphType implementors in assembly which ChatSchema exists 
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();

            // use websocket middleware for ChatSchema at default path /graphql
            app.UseGraphQLWebSockets<PersonsDiseaseSchema>("/graphql");
            // use HTTP middleware for ChatSchema at default path /graphql
            app.UseGraphQL<PersonsDiseaseSchema>("/graphql");
            // use graphql-playground middleware at default path /ui/playground
            app.UseGraphQLPlayground();

            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
}