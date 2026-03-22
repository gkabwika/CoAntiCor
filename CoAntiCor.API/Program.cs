using CoAntiCor.API.Services;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using CoAntiCor.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Program.cs - enable and use AddDbContextFactory
builder.Services.AddDbContextFactory<CoAntiCorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<CoAntiCorDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    contextLifetime: ServiceLifetime.Scoped,    // DbContext instances from factory will be scoped
    optionsLifetime: ServiceLifetime.Scoped);  // DbContextOptions will be registered as scoped


//builder.Services.AddDbContextFactory<CoAntiCorDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//builder.Services.AddDbContext<CoAntiCorDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContextFactory<CoAntiCorDbContext>(ServiceLifetime.Scoped);

//CoAntiCor.Infrastructure.Context.ApplicationDbContext
builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CoAntiCorDbContext>()
    .AddDefaultTokenProviders();

var jwtSection = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });


builder.Services.AddAuthorization(options =>
{
    
    options.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
    options.AddPolicy("Citizen", p => p.RequireRole("Citizen"));
    options.AddPolicy("SpecialInvestigator", p => p.RequireRole("SpecialInvestigator"));
    options.AddPolicy("InternalStaff", p => p.RequireRole("InternalStaff"));
    options.AddPolicy("CanAssignCases", policy =>
        policy.RequireRole("Manager", "Executive"));

    options.AddPolicy("CanViewAllComplaints", policy =>
        policy.RequireRole("Inspector", "Manager", "Executive", "Prosecutor"));

    options.AddPolicy("CanGenerateDossier", policy =>
        policy.RequireRole("Prosecutor", "Executive"));
});

builder.Services.Configure<DraftRetentionSettings>(
    builder.Configuration.GetSection("DraftRetention"));

builder.Services.AddHostedService<DraftCleanupService>();

builder.Services.AddScoped<IComplaintNumberGenerator, ComplaintNumberGenerator>();
builder.Services.AddScoped<IComplaintDraftService, ComplaintDraftService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<BackgroundService, DraftCleanupService>();
builder.Services.AddScoped<IProcessingPhaseEngine, ProcessingPhaseEngine>();
builder.Services.AddScoped<ITribunalDossierService, TribunalDossierService>();
builder.Services.AddScoped<IUxAnalyzer, UxAnalyzer>();
builder.Services.Configure<AttachmentSettings>(
    builder.Configuration.GetSection("AttachmentSettings"));
builder.Services.AddSingleton<IQrCodeService, QrCodeService>();

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
