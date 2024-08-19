using Microsoft.OpenApi.Models;
using System.Reflection;

namespace B3.Api.Setup
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerGenB3(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);                
            });
        }        
    }
}