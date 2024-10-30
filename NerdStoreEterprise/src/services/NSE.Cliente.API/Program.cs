using NSE.Cliente.API;
using NSE.Cliente.API.Configuration;
using NSE.WebAPI.Core.Identidade;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(typeof(Program));

builder.Services.RegisterServices();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration();

app.Run();
