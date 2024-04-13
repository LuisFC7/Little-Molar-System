using System.Text;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Services;
using LittleMolarApi.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);


// Settings for DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IDentist, DentistService>();
builder.Services.AddScoped<UtilitiesServices>();
builder.Services.AddScoped<SessionService>();

// Configuración para JWT Token
builder.Services.AddSingleton<JwtService>();

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddTransient<IDentist, DentistService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
