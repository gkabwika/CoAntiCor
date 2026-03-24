using CoAntiCor.API.Services;
using CoAntiCor.Components;
using CoAntiCor.Components.Account;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using CoAntiCor.Data;
using CoAntiCor.Infrastructure.Context;
using CoAntiCor.Services;
using CoAntiCor.Services.Menu;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ApplicationDbContext = CoAntiCor.Infrastructure.Context.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMemoryCache>(new MemoryCache(new MemoryCacheOptions { TrackStatistics = true, SizeLimit = 25000 }));




// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    });
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

//////////////////////////
///

//builder.Services.AddIdentityCore<User>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//})
//    .AddRoles<Role>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // issuer, audience, signing key, etc.
    };
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContextFactory<CoAntiCorDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddDbContext<CoAntiCorDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<CoAntiCorDbContext>(ServiceLifetime.Transient);

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

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

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en", "fr" };
    options.SetDefaultCulture("en");
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
});

builder.Services.AddTransient<JwtDelegatingHandler>();
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtDelegatingHandler>();
//And inject it where needed:
builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("ApiClient");
});


// HttpClient to call eGUCE.Api (adjust base address)
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7056/"); // your API URL
});
builder.Services.AddScoped<ApiClient>();

// GABY --> A REVOIR CAS 1.1 OU 1.2. ENLEVER EXCEPTION DANS  async Task<AuthenticationState> GetAuthenticationStateAsync()
builder.Services.AddScoped<JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<AuditedNavigationManager>();

builder.Services.Configure<DraftRetentionSettings>(
    builder.Configuration.GetSection("DraftRetention"));
builder.Services.AddHostedService<DraftCleanupService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IComplaintDraftService, ComplaintDraftService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<BackgroundService, DraftCleanupService>();
builder.Services.AddScoped<IProcessingPhaseEngine, ProcessingPhaseEngine>();
builder.Services.AddScoped<ITribunalDossierService, TribunalDossierService>();
builder.Services.AddScoped<IUxAnalyzer, UxAnalyzer>();
builder.Services.AddScoped<IQrCodeService, QrCodeService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.Configure<AttachmentSettings>(
builder.Configuration.GetSection("AttachmentSettings"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
