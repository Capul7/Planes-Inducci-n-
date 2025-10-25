using Api.Auth.Services;
using InduccionAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Bind Jwt options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

// CORS (ajusta origen del frontend)
builder.Services.AddCors(o =>
{
    o.AddPolicy("DevFront", p => p
        .WithOrigins("https://localhost:4173", "http://localhost:4200", "http://localhost:5173", "http://localhost:5173", "https://gray-sky-02830b21e.3.azurestaticapps.net")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()  // opciona
    );
});

// Auth JWT
var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;
var key = Encoding.UTF8.GetBytes(jwt.Key);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var connString = builder.Configuration.GetConnectionString("SqlDb");
builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(connString));

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;//para que dapper mappe bien los geters y setters.

// DI
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IColaboradoresService, ColaboradoresService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseCors("DevFront");
app.UseAuthentication();
app.UseAuthorization();

//Aplica la policy a todos los controladores mapeados
app.MapControllers().RequireCors("DevFront");

//Respuesta al preflight (OPTIONS) para cualquier ruta bajo /api
app.MapMethods("/api/{**path}", new[] { "OPTIONS" }, () => Results.Ok())
   .RequireCors("DevFront");

app.Run();
