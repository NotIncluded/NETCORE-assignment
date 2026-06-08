using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TaskManagementAPI.Data;
using TaskManagementAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// --- 1. SWAGGER CONFIGURATION (WITH JWT SUPPORT) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste your JWT token here to authenticate."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// --- 2. DATABASE CONFIGURATION ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=TaskDb.db"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// --- 3. AUTHENTICATION CONFIGURATION ---
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForTaskManagementAPI123!"))
            };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// --- 4. MIDDLEWARE PIPELINE ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/test-token", () =>
{
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySuperSecretKeyForTaskManagementAPI123!"));
    
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
        expires: DateTime.Now.AddHours(1),
        signingCredentials: credentials);

    return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
});

app.Run();