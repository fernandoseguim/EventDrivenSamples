using CustomersService.Infra.Extensions.Swagger.Filters;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CustomersService.Infra.Extensions.Swagger
{
    public static class SwaggerServicesExtension
    {
        /// <summary>
        /// Add swagger documentation service on dependency injection container 
        /// </summary>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                    {
                        Title = GetApplicationName(),
                        Version = description.ApiVersion.ToString()
                    });
                }
                
                options.SchemaFilter<CustomSchemaExcludeFilter>();
                options.DocumentFilter<LowerCaseDocumentFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        private static string GetApplicationName()
            => Assembly.GetExecutingAssembly().GetName().Name.Replace(".", " ");
    }
}
