using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Torc.Challenge.Application.IoC.Services;
using Torc.Challenge.Infrastructure.IoC;
using Torc.Challenge.Infrastructure.IoC.ORMs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.ApplicationServicesIoC();
builder.Services.InfrastructureORM<EntityFrameworkIoC>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Torc Challenge API",
        Description = "This API is used with a purpose to CRUD the fruits on database.",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Torc Challenge v1");
    c.RoutePrefix = string.Empty;
    c.DocExpansion(DocExpansion.None);
});

app.Run();
