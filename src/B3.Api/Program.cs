using B3.Api.Setup;
using B3.Business.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenB3();

#region B3 Setup/Config

//Injeção de dependências de B3
builder.Services.AddBusinessIoC();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()    
    .Enrich.WithEnvironmentName()
    .Enrich.WithEnvironmentUserName()
    .Enrich.WithProcessName()
    .CreateBootstrapLogger();
//.CreateLogger();

Log.Information("Inicio B3.Api: {Name}", Environment.UserName);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
