using CoAntiCor.API.Services;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
