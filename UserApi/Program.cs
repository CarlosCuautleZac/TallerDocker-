using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Db;
using Services.Implementations;
using Services.Interfaces;
using UserApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("UserAPIDb");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

Appinfo appInfo = new();
builder.Configuration.GetSection("AppInfo").Bind(appInfo);
builder.Services.AddSingleton(appInfo);

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
