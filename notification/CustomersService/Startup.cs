using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using CustomersService.Application.Handlers;
using CustomersService.Application.Handlers.Events;
using CustomersService.Domain.Contracts.Handlers;
using CustomersService.Domain.Contracts.Handlers.Events;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Infra.Extensions.Swagger;
using CustomersService.Infra.Extensions.Versioning;
using CustomersService.Infra.ExternalServices.Email;
using CustomersService.Infra.Repositories;
using CustomersService.Infra.Repositories.CustomerContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace CustomersService
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddSwaggerDocumentation();
            services.AddVersioning();

            services.AddAWSService<IAmazonDynamoDB>(new AWSOptions
            {
                Credentials = new BasicAWSCredentials("AKIAVSTVILGI3XFQ3WPB", "mwFZ0JSr9Sh48TCAQHuFw8Q/ToWIv5vu/9CJ1Ohv"),
                Region = RegionEndpoint.USWest2
            });

            services.AddSingleton<IRepositoryConfiguration, CustomersRepositoryConfiguration>();
            services.AddSingleton<ICustomersRepository, CustomersRepository>();

            services.AddHttpClient<IValidateEmailService, ValidateEmailService>(o =>
            {
                o.BaseAddress = new Uri("http://localhost:6000/api/v1/emails");
            });

            services.AddTransient<ICreateCustomerCommandHandler, CreateCustomerCommandHandler>();

            services.RegisterEasyNetQ("host=localhost");

            services.AddAsyncInitializer<AsyncInitializer>();

            services.AddTransient<IEmailTokenWasValidatedHandler, EmailTokenWasValidatedHandler>();
            services.AddTransient<IEmailTokenWasExpiredHandler, EmailTokenWasExpiredHandler>();
            services.AddHostedService<Worker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider versionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseVersionedSwagger(versionProvider);
        }
    }
}
