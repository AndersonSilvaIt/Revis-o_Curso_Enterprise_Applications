using Microsoft.OpenApi.Models;
using System.Net.NetworkInformation;

namespace NSE.Catalogo.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection servicecs)
        {
            servicecs.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Catálogo API",
                    Description = "API Curso Enterprise Aplication ASP.NET CORE",
                    Contact = new OpenApiContact() { Name = "Anderson", Email = "anderson.silvait@outlook.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://www.google.com") }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
