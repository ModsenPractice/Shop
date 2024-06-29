using Shop.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Shop.DAL;
using Shop.BLL.Extentions;
using Shop.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentity(); 
builder.Services.ConfigureLogger(); 
builder.Services.ConfigureAutoFluentValidation(); 

var connectionString = builder.Configuration.GetConnectionString("ShopDatabase");
builder.Services.ConfigureDatabase(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
