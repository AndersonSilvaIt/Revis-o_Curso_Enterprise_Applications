using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Data;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Carrinho.API.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarrinhoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Total", buider =>
                            buider
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.MapControllers();
        }
    }
}