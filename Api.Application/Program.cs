using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interface;
using Api.Domain.Interfaces.Services.User;
using Api.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddDbContext<MyContext>(
    options => options.UseMySql(
        "Server=localhost; Port=3306;Database=dbAPI;Uid=root;Pwd=root",
        new MySqlServerVersion(ServerVersion.AutoDetect("Server=localhost; Port=3306;Database=dbAPI;Uid=root;Pwd=root"))
            )
        );
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
