using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration(builder.Configuration);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseMvcConfiguration();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Catalogo}/{action=Index}/{id?}");
});

app.Run();
