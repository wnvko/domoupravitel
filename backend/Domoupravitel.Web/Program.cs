using System.Text;
using Domoupravitel.Data;
using Domoupravitel.Data.UnitOfWork;
using Domoupravitel.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
    .AddIdentityCore<IdentityUser>(options =>
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
