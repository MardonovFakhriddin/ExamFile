using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IContext,DapperContext>();
builder.Services.AddScoped<IProductService<Product>, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "BankManagment"));
}

app.MapControllers();
app.Run();