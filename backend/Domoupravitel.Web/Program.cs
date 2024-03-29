using System.Text;
using System.Text.Json.Serialization;
using Domoupravitel.Data;
using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Models;
using Domoupravitel.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(o => o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "domoupravitel",
            ValidAudience = "domoupravitel",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0e9234e9fc4ee2f043f824c45ef5329c8d502057028bba8d78746586e2905c57")),
        };
    });

builder.Services
    .AddIdentityCore<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<DomoupravitelDbContext>();

builder.Services.AddDbContext<DomoupravitelDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        x => x.MigrationsAssembly("Domoupravitel.Web"));
});

builder.Services.AddScoped<IDomoupravitelDbContext, DomoupravitelDbContext>();
builder.Services.AddScoped<IDomoupravitelData, DomoupravitelData>();
builder.Services.AddScoped<TokenService, TokenService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "debug",
        policy =>
        {
            policy.WithOrigins("http://localhost", "http://localhost:4200", "http://127.0.0.1", "http://127.0.0.1:4200", "127.0.0.1", "127.0.0.1:4200")
                  .AllowCredentials()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    options.AddPolicy(name: "prod",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://www.ilina.be",
                    "https://www.ilina.be",
                    "http://192.168.0.104",
                    "https://192.168.0.104",
                    "192.168.0.104",
                    "http://localhost",
                    "https://localhost",
                    "localhost:8080")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Auth",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("debug");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("prod");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
