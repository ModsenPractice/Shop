using Shop.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Shop.DAL;
using Shop.DAL.Contexts;
using Shop.BLL;
using Shop.BLL.Common.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureBLL();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureLogger();

var connectionString = builder.Configuration.GetConnectionString("ShopDatabase");
builder.Services.ConfigureDatabase(connectionString);

builder.Services.ConfigureOpenIdDict();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
