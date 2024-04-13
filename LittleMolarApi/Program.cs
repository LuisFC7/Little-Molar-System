using System.Text;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Services;
using LittleMolarApi.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
=======
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507


var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD

=======
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507
// Settings for DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
// {
//     options.SignIn.RequireConfirmedAccount = true;
// })
// .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IDentist, DentistService>();
builder.Services.AddScoped<UtilitiesServices>();
builder.Services.AddScoped<SessionService>();

<<<<<<< HEAD
// Configuración para JWT Token
builder.Services.AddSingleton<JwtService>();

builder.Services.AddAuthorization();
=======

// builder.Services.AddScoped<ISessionImp, SessionService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSecret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Configuración de autorización
builder.Services.AddAuthorization();


builder.Services.AddScoped<ISessionImp>(provider =>
{
        var configuration = provider.GetRequiredService<IConfiguration>(); // Obtener la configuración
        var jwtSecret = configuration["JwtSecret"]; // Obtener el secreto JWT desde la configuración
        var context = provider.GetRequiredService<ApplicationDbContext>();
        var tokenService = new TokenService(jwtSecret);
        return new SessionService(context, tokenService, configuration);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ForwardDefaultSelector = CTX =>{
        return CTX.Request.Path.StartsWithSegments("/api")? JwtBearerDefaults.AuthenticationScheme : null;
    };
});

// Add services to the container.
>>>>>>> 50267a9a48adbcf5776542b4e0dabb6d7bd9f507

builder.Services.AddControllers();
builder.Services.AddTransient<IDentist, DentistService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Litle Molar API", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

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