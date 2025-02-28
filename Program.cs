using Microsoft.EntityFrameworkCore;
using TodoApi1;
using TodoApi1.Helpers;
using TodoApi1.Interfaces;
using TodoApi1.Models;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from the resource file
string connectionString = ConnectionHelper.GetConnectionString();

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<IEmailService, EmailService>();

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
