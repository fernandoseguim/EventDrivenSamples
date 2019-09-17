using CustomersService.Infra.Extensions.Swagger;
using CustomersService.Infra.Extensions.Versioning;
using EmailsService.Application;
using EmailsService.Domain.Contracts.Handlers;
using EmailsService.Infra.ExternalServices.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SendGrid;

namespace EmailsService
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

            services.AddSingleton<ISendGridClient>(client => new SendGridClient("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"));
            services.AddSingleton<IMailProvider, SendGridMailProvider>();

            services.RegisterEasyNetQ("host=localhost");

            services.AddTransient<IEmailTokenCommandHandler, EmailTokenCommandHandler>();
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
