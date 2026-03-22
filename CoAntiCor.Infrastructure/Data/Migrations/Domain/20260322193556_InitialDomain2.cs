using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoAntiCor.Infrastructure.Data.Migrations.Domain
{
    /// <inheritdoc />
    public partial class InitialDomain2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizedOfficials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrivateCorporationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguagePreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveYear = table.Column<int>(type: "int", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedOfficials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankTransit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSubArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankTransit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankSWIFT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BitCoins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitCoinURI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitCoinUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitCoinQRCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantTransit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantSubArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitCoins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashOnDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNoBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FraisBancaire = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Merchant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashOnDeliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Civilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintDrafts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReporterUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentStep = table.Column<int>(type: "int", nullable: false),
                    StateJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AccessCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceLinkToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceLinkTokenExpiresUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDrafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintNumberSequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    LastNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintNumberSequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailFrom = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    EmailCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    EmailBCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsEmails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencySymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    NextAttemptUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelatedEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EmailCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    EmailCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    EmailBCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootPrintTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootPrintTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FredRequest",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestNumber = table.Column<long>(type: "bigint", nullable: false),
                    ResponseTimeHours = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DevHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DevOpsTicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkStream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contractual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WBSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddPlatformNextGen = table.Column<bool>(type: "bit", nullable: false),
                    AddPlatformAccess = table.Column<bool>(type: "bit", nullable: false),
                    AddPlatformExcel = table.Column<bool>(type: "bit", nullable: false),
                    TeamResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FredRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiftCardPayInAdvances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftCardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiftCardCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCardPayInAdvances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentOffices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TitleFrench = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileMoneys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileMoneyBuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileMoneyBuyerPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileMoneys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    LogMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayPalBuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayPalBuyerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonRejecteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonRejecteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeCodeTableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    LookupValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeCodeTableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    DescriptionEnglish = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpouseType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpouseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommuneName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintDraftActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DraftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDraftActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintDraftActivities_ComplaintDrafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "ComplaintDrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ServiceRequestNumber = table.Column<int>(type: "int", nullable: false),
                    VersionNum = table.Column<int>(type: "int", nullable: false),
                    EmailTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    EmailCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    EmailBCC = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    SenderEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FredRequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionLogs_FredRequest_FredRequestID",
                        column: x => x.FredRequestID,
                        principalTable: "FredRequest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FredRequestFiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FredRequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    StoredPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    UploadedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FredRequestFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FredRequestFiles_FredRequest_FredRequestID",
                        column: x => x.FredRequestID,
                        principalTable: "FredRequest",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFrench = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionFrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentTypes_IncidentCategories_IncidentCategoryId",
                        column: x => x.IncidentCategoryId,
                        principalTable: "IncidentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quartiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommuneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quartiers_Communes_CommuneId",
                        column: x => x.CommuneId,
                        principalTable: "Communes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAttachments_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailExecutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ExecutionStep = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAttemptDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    EmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailExecutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailExecutions_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncidentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeGroups = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    AgeGroup = table.Column<int>(type: "int", nullable: true),
                    ReporterUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReporterContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GovernmentOfficeId = table.Column<int>(type: "int", nullable: true),
                    GovernmentOfficeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfficialNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_GovernmentOffices_GovernmentOfficeId1",
                        column: x => x.GovernmentOfficeId1,
                        principalTable: "GovernmentOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_IncidentCategories_IncidentCategoryId",
                        column: x => x.IncidentCategoryId,
                        principalTable: "IncidentCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Users_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOfficialEvidence = table.Column<bool>(type: "bit", nullable: false),
                    EvidenceByOfficialUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintAttachments_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldStatus = table.Column<int>(type: "int", nullable: false),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    ChangedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintHistories_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintHistories_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintRewards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EligibilityStatus = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintRewards_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsVictimPerson = table.Column<bool>(type: "bit", nullable: false),
                    IsReporterPerson = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CivilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhonePersonal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneBusiness = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpouseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPeople_Civilities_CivilityId",
                        column: x => x.CivilityId,
                        principalTable: "Civilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPeople_Complaints_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPeople_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPeople_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPeople_SpouseType_SpouseTypeId",
                        column: x => x.SpouseTypeId,
                        principalTable: "SpouseType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfficialDiscussion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discussion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialDiscussion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialDiscussion_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessingPhases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhaseType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessingPhases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessingPhases_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessingPhases_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SuiteNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StreetType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressSubArea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Quartier = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    MainAddress = table.Column<bool>(type: "bit", nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameFrench = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DecisionControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemUnderControl = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ValidationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonRejectedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionControls_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecisionControls_ReasonRejecteds_ReasonRejectedId",
                        column: x => x.ReasonRejectedId,
                        principalTable: "ReasonRejecteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecisionControls_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonSpouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Divorced = table.Column<bool>(type: "bit", nullable: true),
                    DivorceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonSpouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPersonSpouses_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VictimOrganization = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsReporterOrganization = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnterpriseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNumP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicPeople_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicPeople_EnterpriseTypes_EnterpriseTypeId",
                        column: x => x.EnterpriseTypeId,
                        principalTable: "EnterpriseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicPeople_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicPeople_OrganizationCategories_OrganizationCategoryId",
                        column: x => x.OrganizationCategoryId,
                        principalTable: "OrganizationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalPersonAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NaturalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalPersonAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturalPersonAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NaturalPersonAddresses_NaturalPeople_NaturalPersonId",
                        column: x => x.NaturalPersonId,
                        principalTable: "NaturalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    HeadQuarter = table.Column<bool>(type: "bit", nullable: true),
                    OperationLocation = table.Column<bool>(type: "bit", nullable: true),
                    OwnerPrivateResidentialLocation = table.Column<bool>(type: "bit", nullable: true),
                    PhysicPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarkForDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAddresses_PhysicPeople_PhysicPersonId",
                        column: x => x.PhysicPersonId,
                        principalTable: "PhysicPeople",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CountryCode", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "ProvinceCode", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "Kinshasa", "COD", null, null, null, null, true, false, "KIN", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Lubumbashi", "COD", null, null, null, null, true, false, "HAK", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "Goma", "COD", null, null, null, null, true, false, "NKV", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "Bukavu", "COD", null, null, null, null, true, false, "SUD", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "Bunia", "COD", null, null, null, null, true, false, "ITU", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000006"), "Kisangani", "COD", null, null, null, null, true, false, "TUE", null, null }
                });

            migrationBuilder.InsertData(
                table: "ComplaintNumberSequences",
                columns: new[] { "Id", "LastNumber", "Year" },
                values: new object[] { 1, 0L, 2026 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "NaturalPersonId", "UpdatedBy", "UpdatedDT" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), "COD", null, null, null, null, true, false, "Democratic Republic of the Congo", "Democratic Republic of the Congo", "République Démocratique du Congo", null, null, null });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "M", null, null, null, null, true, false, "Male", "Male", "Homme", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "F", null, null, null, null, true, false, "Female", "Female", "Femme", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "O", null, null, null, null, true, false, "Other", "Other", "Autre", null, null }
                });

            migrationBuilder.InsertData(
                table: "GovernmentOffices",
                columns: new[] { "Id", "AddressLine", "City", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "Email", "IsActive", "MarkForDelete", "Name", "Phone", "Province", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Boulevard du 30 Juin, Gombe", "Kinshasa", null, null, null, null, "contact@justice.cd", true, false, "Ministry of Justice", "+243 820 000 001", "Kinshasa", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Avenue des Huileries, Gombe", "Kinshasa", null, null, null, null, "info@aplc.cd", true, false, "Anti-Corruption Agency (APLC)", "+243 820 000 002", "Kinshasa", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Avenue Kasa-Vubu", "Lubumbashi", null, null, null, null, "governor@hautkatanga.cd", true, false, "Provincial Governor's Office", "+243 820 000 003", "Haut-Katanga", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Boulevard du 30 Juin", "Kinshasa", null, null, null, null, "finance@min.cd", true, false, "Ministry of Finance", "+243 820 000 004", "Kinshasa", null, null }
                });

            migrationBuilder.InsertData(
                table: "IncidentCategories",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "Description", "DescriptionFrench", "IsActive", "MarkForDelete", "Name", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "FIN", null, null, null, null, "Crimes involving public funds, assets, or financial deception.", "Crimes impliquant des fonds publics, des biens ou des tromperies financières.", true, false, "Financial Misconduct", "Infractions financières", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "ADM", null, null, null, null, "Misuse of administrative authority or violation of public duty.", "Mauvaise utilisation de l’autorité administrative ou violation du devoir public.", true, false, "Administrative Misconduct", "Manquements administratifs", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "COR", null, null, null, null, "Acts involving undue influence, bribery, or coercion.", "Actes impliquant une influence indue, des pots-de-vin ou de la coercition.", true, false, "Corruption and Influence", "Corruption et influence", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "PRO", null, null, null, null, "Conflicts or illegal actions involving land or property.", "Conflits ou actions illégales impliquant des terres ou des biens.", true, false, "Land and Property Disputes", "Litiges fonciers et immobiliers", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "DOC", null, null, null, null, "Forgery, illegal reproduction, or unauthorized publication.", "Falsification, reproduction illégale ou publication non autorisée.", true, false, "Document and Information Crimes", "Crimes liés aux documents et à l’information", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000006"), "SEX", null, null, null, null, "Sexual harassment or related misconduct.", "Harcèlement sexuel ou inconduite connexe.", true, false, "Sexual Misconduct", "Inconduite sexuelle", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000007"), "SEC", null, null, null, null, "High-risk safety warning.", "Avertissement sécuritaire à haut risque.", true, false, "High-risk safety warning", "Avertissement sécuritaire à haut risque", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000008"), "OTH", null, null, null, null, "Other", "Autre.", true, false, "Other", "Autre", null, null }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "SINGLE", null, null, null, null, true, false, "Single", "Single", "Célibataire", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "MARRIED", null, null, null, null, true, false, "Married", "Married", "Marié(e)", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "DIVORCED", null, null, null, null, true, false, "Divorced", "Divorced", "Divorcé(e)", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "WIDOWED", null, null, null, null, true, false, "Widowed", "Widowed", "Veuf / Veuve", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "SEPARATED", null, null, null, null, true, false, "Separated", "Separated", "Séparé(e)", null, null }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "DisplayOrder", "Icon", "IsActive", "ParentId", "Role", "Title", "TitleFrench", "Url" },
                values: new object[,]
                {
                    { 1, 1, "fa-solid fa-house", true, null, null, "Home", "Accueil", "/" },
                    { 2, 2, "fa-solid fa-file-circle-plus", true, null, null, "Report a Complaint", "Signaler une plainte", "/wizard" },
                    { 3, 3, "fa-solid fa-magnifying-glass", true, null, null, "Track My Complaint", "Suivre ma plainte", "/track-complaint" },
                    { 4, 4, "fa-solid fa-circle-question", true, null, null, "FAQ", "Questions & Reponses", "/faq" },
                    { 5, 5, "fa-solid fa-envelope", true, null, null, "Legal", "Mentions Légales", "/legal" },
                    { 6, 6, "fa-solid fa-envelope", true, null, null, "Contact", "Contactez-nous", "/contact" },
                    { 10, 10, "fa-solid fa-briefcase", true, null, "Staff", "Staff", "Personnel", "#" },
                    { 11, 1, "fa-solid fa-gauge", true, 10, "Staff", "Dashboard", "Tableau de bord", "/internal/dashboard" },
                    { 12, 2, "fa-solid fa-folder-open", true, 10, "Staff", "Complaints", "Plaintes", "/internal/complaints" },
                    { 13, 3, "fa-solid fa-user-check", true, 10, "Staff", "Assignments", "Attributions", "/internal/assignments" },
                    { 14, 4, "fa-solid fa-clipboard-list", true, 10, "Staff", "Audit Logs", "Journaux d'audit", "/internal/audit-logs" },
                    { 15, 5, "fa-solid fa-chart-line", true, 10, "Staff", "Draft Analytics", "Analytique des brouillons", "/internal/draft-analytics" },
                    { 20, 20, "fa-solid fa-user-tie", true, null, "Executive", "Executive", "Direction", "#" },
                    { 21, 1, "fa-solid fa-chart-pie", true, 20, "Executive", "Oversight Dashboard", "Tableau de bord de surveillance", "/executive/oversight" },
                    { 22, 2, "fa-solid fa-fire", true, 20, "Executive", "Heatmaps", "Cartes de chaleur", "/internal/draft-heatmap" },
                    { 23, 3, "fa-solid fa-shield-halved", true, 20, "Executive", "Suspicious Activity", "Activité suspecte", "/regulator/suspicious-activity" },
                    { 24, 4, "fa-solid fa-mobile-screen", true, 20, "Executive", "Device Security Reports", "Rapports de sécurité des appareils", "/regulator/device-security" },
                    { 25, 5, "fa-solid fa-lightbulb", true, 20, "Executive", "UX Optimization Report", "Rapport d'optimisation UX", "/internal/ux-report" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "DescriptionEnglish", "DescriptionFrench", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "MOBILE_MONEY", null, null, null, null, "Payment via mobile services such as M-Pesa, Airtel Money, Orange Money.", "Paiement via services mobiles tels que M-Pesa, Airtel Money, Orange Money.", true, false, "Mobile Money", "Mobile Money", "Mobile Money", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "BANK_TRANSFER", null, null, null, null, "Payment made via bank transfer.", "Paiement effectué par virement bancaire.", true, false, "Bank Transfer", "Bank Transfer", "Virement bancaire", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "CASH", null, null, null, null, "Payment in cash.", "Paiement en espèces.", true, false, "Cash", "Cash", "Espèces", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "PAYPAL", null, null, null, null, "Payment via PayPal.", "Paiement via PayPal.", true, false, "PayPal", "PayPal", "PayPal", null, null }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Code", "CountryCode", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "KIN", "COD", null, null, null, null, true, false, "Kinshasa", "Kinshasa", "Kinshasa", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "KSU", "COD", null, null, null, null, true, false, "Kongo Central", "Kongo Central", "Kongo Central", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "KWG", "COD", null, null, null, null, true, false, "Kwango", "Kwango", "Kwango", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "KWL", "COD", null, null, null, null, true, false, "Kwilu", "Kwilu", "Kwilu", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "MAI", "COD", null, null, null, null, true, false, "Mai-Ndombe", "Mai-Ndombe", "Mai-Ndombe", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "KAS", "COD", null, null, null, null, true, false, "Kasai", "Kasai", "Kasaï", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "KAC", "COD", null, null, null, null, true, false, "Kasai Central", "Kasai Central", "Kasaï Central", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "KAE", "COD", null, null, null, null, true, false, "Kasai Oriental", "Kasai Oriental", "Kasaï Oriental", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "LUA", "COD", null, null, null, null, true, false, "Lomami", "Lomami", "Lomami", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "SUK", "COD", null, null, null, null, true, false, "Sankuru", "Sankuru", "Sankuru", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000011"), "MAN", "COD", null, null, null, null, true, false, "Maniema", "Maniema", "Maniema", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000012"), "SUD", "COD", null, null, null, null, true, false, "South Kivu", "South Kivu", "Sud-Kivu", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000013"), "NKV", "COD", null, null, null, null, true, false, "North Kivu", "North Kivu", "Nord-Kivu", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000014"), "ITU", "COD", null, null, null, null, true, false, "Ituri", "Ituri", "Ituri", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000015"), "HAU", "COD", null, null, null, null, true, false, "Haut-Uele", "Haut-Uele", "Haut-Uele", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000016"), "TUE", "COD", null, null, null, null, true, false, "Tshopo", "Tshopo", "Tshopo", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000017"), "BAS", "COD", null, null, null, null, true, false, "Bas-Uele", "Bas-Uele", "Bas-Uele", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000018"), "MBO", "COD", null, null, null, null, true, false, "Mongala", "Mongala", "Mongala", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000019"), "NUB", "COD", null, null, null, null, true, false, "North Ubangi", "North Ubangi", "Nord-Ubangi", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000020"), "SBU", "COD", null, null, null, null, true, false, "South Ubangi", "South Ubangi", "Sud-Ubangi", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000021"), "EQU", "COD", null, null, null, null, true, false, "Equateur", "Equateur", "Équateur", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000022"), "TSH", "COD", null, null, null, null, true, false, "Tshuapa", "Tshuapa", "Tshuapa", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000023"), "LUAH", "COD", null, null, null, null, true, false, "Haut-Lomami", "Haut-Lomami", "Haut-Lomami", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000024"), "LUAU", "COD", null, null, null, null, true, false, "Lualaba", "Lualaba", "Lualaba", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000025"), "HAK", "COD", null, null, null, null, true, false, "Haut-Katanga", "Haut-Katanga", "Haut-Katanga", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000026"), "TAN", "COD", null, null, null, null, true, false, "Tanganyika", "Tanganyika", "Tanganyika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ReasonRejecteds",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "DescriptionEnglish", "DescriptionFrench", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "INSUFFICIENT_INFO", null, null, null, null, "The complaint does not contain enough detail to allow an investigation.", "La plainte ne contient pas suffisamment de détails pour permettre une enquête.", true, false, "Insufficient Information", "Insufficient Information", "Informations insuffisantes", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "OUT_OF_SCOPE", null, null, null, null, "The complaint does not fall under the agency's jurisdiction.", "La plainte ne relève pas de la compétence de l'agence.", true, false, "Outside Jurisdiction", "Outside Jurisdiction", "Hors compétence", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "NO_EVIDENCE", null, null, null, null, "No evidence or documentation was provided.", "Aucune preuve ou documentation n'a été fournie.", true, false, "No Supporting Evidence", "No Supporting Evidence", "Aucune preuve", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "MALICIOUS", null, null, null, null, "The complaint appears intentionally false or malicious.", "La plainte semble être intentionnellement fausse ou malveillante.", true, false, "Malicious or False Report", "Malicious or False Report", "Rapport malveillant ou faux", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "DUPLICATE", null, null, null, null, "The complaint has already been submitted previously.", "La plainte a déjà été soumise auparavant.", true, false, "Duplicate Complaint", "Duplicate Complaint", "Plainte dupliquée", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoadTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "LookupValue", "MarkForDelete", "Name", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), null, null, null, null, true, "AV", false, "Avenue", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000002"), null, null, null, null, true, "BD", false, "Boulevard", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000003"), null, null, null, null, true, "RT", false, "Route", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000004"), null, null, null, null, true, "RN", false, "Route Nationale", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000005"), null, null, null, null, true, "CH", false, "Chaussée", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000006"), null, null, null, null, true, "RUE", false, "Rue", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11121111-2312-1111-3333-111117111111"), "Admin" },
                    { new Guid("22212222-3333-2222-3333-222272622222"), "Citizen" },
                    { new Guid("33134333-3223-1111-3333-333345333333"), "InternalStaff" },
                    { new Guid("44544424-4454-2244-3354-444433444444"), "Manager" },
                    { new Guid("55556555-5555-2155-5755-555352255555"), "Executive" },
                    { new Guid("66162666-2266-7377-4466-616661166666"), "Inspector" },
                    { new Guid("77737877-1277-5555-7577-777947777777"), "Prosecutor" },
                    { new Guid("88734177-6277-2555-7567-872147377777"), "SpecialInvestigator" }
                });

            migrationBuilder.InsertData(
                table: "SpouseType",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "NameEnglish", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "HUSBAND", null, null, null, null, true, false, "Husband", "Husband", "Mari", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "WIFE", null, null, null, null, true, false, "Wife", "Wife", "Femme", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "PARTNER", null, null, null, null, true, false, "Partner", "Partner", "Partenaire", null, null }
                });

            migrationBuilder.InsertData(
                table: "Territories",
                columns: new[] { "Id", "Code", "CountryCode", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "ProvinceCode", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "GOM", "COD", null, null, null, null, true, false, "Goma", "NKV", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "BEN", "COD", null, null, null, null, true, false, "Beni", "NKV", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "RUT", "COD", null, null, null, null, true, false, "Uvira", "SUD", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "KAS", "COD", null, null, null, null, true, false, "Luebo", "KAS", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "KIK", "COD", null, null, null, null, true, false, "Mbanza-Ngungu", "KSU", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "KIP", "COD", null, null, null, null, true, false, "Kasumbalesa", "HAK", null, null }
                });

            migrationBuilder.InsertData(
                table: "Communes",
                columns: new[] { "Id", "CityId", "CommuneName", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("30000000-0000-0000-0000-000000000001"), "Gombe", null, null, null, null, true, false, null, null },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("30000000-0000-0000-0000-000000000001"), "Kinshasa", null, null, null, null, true, false, null, null },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("30000000-0000-0000-0000-000000000001"), "Kasa-Vubu", null, null, null, null, true, false, null, null },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000001"), "Lingwala", null, null, null, null, true, false, null, null },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("30000000-0000-0000-0000-000000000001"), "Ngaliema", null, null, null, null, true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "Description", "DescriptionFrench", "IncidentCategoryId", "IsActive", "MarkForDelete", "Name", "NameFrench", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, "Offering, giving, receiving, or soliciting something of value to influence an official action.", "Offrir, donner, recevoir ou solliciter quelque chose de valeur pour influencer une action officielle.", new Guid("20000000-0000-0000-0000-000000000003"), true, false, "Bribery", "Corruption (Pot-de-vin)", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), null, null, null, null, "Misappropriation or theft of public funds or assets entrusted to an official.", "Appropriation ou vol de fonds ou biens publics confiés à un agent.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Embezzlement", "Détournement de fonds", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), null, null, null, null, "Deception intended to result in financial or personal gain at the expense of the state.", "Tromperie visant à obtenir un gain financier ou personnel au détriment de l'État.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Fraud", "Fraude", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), null, null, null, null, "A situation where an official’s personal interests improperly influence their public duties.", "Situation où les intérêts personnels d’un agent influencent indûment ses fonctions publiques.", new Guid("20000000-0000-0000-0000-000000000002"), true, false, "Conflict of Interest", "Conflit d’intérêts", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), null, null, null, null, "Using official authority for personal gain or to harm others.", "Utilisation de l’autorité officielle pour un gain personnel ou pour nuire à autrui.", new Guid("20000000-0000-0000-0000-000000000002"), true, false, "Abuse of Power", "Abus de pouvoir", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000006"), null, null, null, null, "Favoring relatives or friends for jobs, contracts, or benefits.", "Favoriser des proches ou amis pour des emplois, contrats ou avantages.", new Guid("20000000-0000-0000-0000-000000000002"), true, false, "Nepotism", "Népotisme", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000007"), null, null, null, null, "Illegal avoidance of paying taxes owed to the government.", "Éviter illégalement de payer les impôts dus à l’État.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Tax Evasion", "Évasion fiscale", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000008"), null, null, null, null, "Manipulation of bidding, contracting, or procurement processes.", "Manipulation des processus d’appel d’offres, de contrats ou d’achats publics.", new Guid("20000000-0000-0000-0000-000000000003"), true, false, "Public Procurement Fraud", "Fraude dans les marchés publics", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000009"), null, null, null, null, "Using government vehicles, funds, or assets for personal purposes.", "Utilisation des véhicules, fonds ou biens de l’État à des fins personnelles.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Misuse of Public Resources", "Utilisation abusive des ressources publiques", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000010"), null, null, null, null, "Forcing individuals to give money or favors under threat or coercion.", "Forcer des individus à donner de l’argent ou des faveurs sous menace ou coercition.", new Guid("20000000-0000-0000-0000-000000000003"), true, false, "Extortion", "Extorsion", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000011"), null, null, null, null, "Unauthorized copying or duplication of protected documents or materials.", "Copie ou duplication non autorisée de documents ou de matériels protégés.", new Guid("20000000-0000-0000-0000-000000000005"), true, false, "Illegal Reproduction", "Reproduction illégale", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000012"), null, null, null, null, "Publishing restricted, confidential, or unauthorized materials.", "Publication de documents restreints, confidentiels ou non autorisés.", new Guid("20000000-0000-0000-0000-000000000005"), true, false, "Illegal Publication", "Publication illégale", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000013"), null, null, null, null, "Conflicts involving land ownership, boundaries, or illegal occupation.", "Conflits liés à la propriété, aux limites ou à l’occupation illégale des terres.", new Guid("20000000-0000-0000-0000-000000000004"), true, false, "Land Dispute", "Conflit foncier", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000014"), null, null, null, null, "Altering or forging official documents, signatures, or records.", "Altération ou falsification de documents, signatures ou registres officiels.", new Guid("20000000-0000-0000-0000-000000000005"), true, false, "Falsification", "Falsification", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000015"), null, null, null, null, "Concealing the origins of illegally obtained money.", "Dissimuler l’origine de fonds obtenus illégalement.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Money Laundering", "Blanchiment d’argent", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000016"), null, null, null, null, "Illegal acquisition or occupation of land, often through coercion or fraud.", "Acquisition ou occupation illégale de terres, souvent par coercition ou fraude.", new Guid("20000000-0000-0000-0000-000000000004"), true, false, "Land Grabbing", "Accaparement des terres", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000017"), null, null, null, null, "Unfair hiring practices that favor certain individuals without merit.", "Pratiques d’embauche injustes favorisant certains individus sans mérite.", new Guid("20000000-0000-0000-0000-000000000002"), true, false, "Hiring Favoritism", "Favoritisme dans le recrutement", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000018"), null, null, null, null, "Unauthorized possession or transfer of state-owned assets.", "Possession ou transfert non autorisé de biens appartenant à l’État.", new Guid("20000000-0000-0000-0000-000000000001"), true, false, "Illegal Acquisition of Public Property", "Acquisition illégale de biens publics", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000019"), null, null, null, null, "Seizing property without legal authority or due process.", "Saisie de biens sans autorité légale ou procédure régulière.", new Guid("20000000-0000-0000-0000-000000000004"), true, false, "Confiscation of Property Belonging to Others", "Confiscation de biens appartenant à autrui", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000020"), null, null, null, null, "Mistreatment, intimidation, or exploitation of employees or subordinates.", "Mauvais traitements, intimidation ou exploitation d’employés ou de subordonnés.", new Guid("20000000-0000-0000-0000-000000000002"), true, false, "Abuse of Personnel", "Abus de personnel", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000021"), null, null, null, null, "Unwanted sexual advances, requests, or conduct in the workplace.", "Avances, demandes ou comportements sexuels non désirés sur le lieu de travail.", new Guid("20000000-0000-0000-0000-000000000006"), true, false, "Sexual Harassment", "Harcèlement sexuel", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000022"), null, null, null, null, "High - risk safety warning", "Avertissement sécuritaire à haut risque.", new Guid("20000000-0000-0000-0000-000000000007"), true, false, "High-risk safety warning", "Avertissement sécuritaire à haut risque", null, null },
                    { new Guid("10000000-0000-0000-0000-000000000023"), null, null, null, null, "Unclassified - Other", "Autre ou no classifié.", new Guid("20000000-0000-0000-0000-000000000008"), true, false, "Unclassified - Other", "Autre ou no classifié", null, null }
                });

            migrationBuilder.InsertData(
                table: "Quartiers",
                columns: new[] { "Id", "CommuneId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IsActive", "MarkForDelete", "Name", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), new Guid("40000000-0000-0000-0000-000000000001"), null, null, null, null, true, false, "Quartier Résidentiel", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000002"), new Guid("40000000-0000-0000-0000-000000000001"), null, null, null, null, true, false, "Quartier Commercial", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLogs_FredRequestID",
                table: "ActionLogs",
                column: "FredRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NaturalPersonId",
                table: "Addresses",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityType_EntityId",
                table: "AuditLogs",
                columns: new[] { "EntityType", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_TimestampUtc",
                table: "AuditLogs",
                column: "TimestampUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_CityId",
                table: "Communes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintAttachments_ComplaintId",
                table: "ComplaintAttachments",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintDraftActivities_DraftId",
                table: "ComplaintDraftActivities",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintHistories_ChangedByUserId",
                table: "ComplaintHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintHistories_ComplaintId",
                table: "ComplaintHistories",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintRewards_ComplaintId",
                table: "ComplaintRewards",
                column: "ComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AssignedToUserId",
                table: "Complaints",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplaintNumber",
                table: "Complaints",
                column: "ComplaintNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_GovernmentOfficeId1",
                table: "Complaints",
                column: "GovernmentOfficeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_IncidentCategoryId",
                table: "Complaints",
                column: "IncidentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_IncidentTypeId",
                table: "Complaints",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ReporterUserId",
                table: "Complaints",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NaturalPersonId",
                table: "Countries",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionControls_NaturalPersonId",
                table: "DecisionControls",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionControls_ReasonRejectedId",
                table: "DecisionControls",
                column: "ReasonRejectedId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionControls_SiteId",
                table: "DecisionControls",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAttachments_EmailId",
                table: "EmailAttachments",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailExecutions_EmailId",
                table: "EmailExecutions",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailTemplateId",
                table: "Emails",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FredRequestFiles_FredRequestID",
                table: "FredRequestFiles",
                column: "FredRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_IncidentCategoryId",
                table: "IncidentTypes",
                column: "IncidentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_CivilityId",
                table: "NaturalPeople",
                column: "CivilityId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_GenderId",
                table: "NaturalPeople",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_MaritalStatusId",
                table: "NaturalPeople",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_NaturalPersonId",
                table: "NaturalPeople",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPeople_SpouseTypeId",
                table: "NaturalPeople",
                column: "SpouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonAddresses_AddressId",
                table: "NaturalPersonAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonAddresses_NaturalPersonId",
                table: "NaturalPersonAddresses",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalPersonSpouses_NaturalPersonId",
                table: "NaturalPersonSpouses",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialDiscussion_ComplaintId",
                table: "OfficialDiscussion",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAddresses_PhysicPersonId",
                table: "OrganizationAddresses",
                column: "PhysicPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicPeople_ComplaintId",
                table: "PhysicPeople",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicPeople_EnterpriseTypeId",
                table: "PhysicPeople",
                column: "EnterpriseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicPeople_NaturalPersonId",
                table: "PhysicPeople",
                column: "NaturalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicPeople_OrganizationCategoryId",
                table: "PhysicPeople",
                column: "OrganizationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPhases_AssignedToUserId",
                table: "ProcessingPhases",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessingPhases_ComplaintId",
                table: "ProcessingPhases",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Quartiers_CommuneId",
                table: "Quartiers",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "AuthorizedOfficials");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BitCoins");

            migrationBuilder.DropTable(
                name: "CashOnDeliveries");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "ComplaintAttachments");

            migrationBuilder.DropTable(
                name: "ComplaintDraftActivities");

            migrationBuilder.DropTable(
                name: "ComplaintHistories");

            migrationBuilder.DropTable(
                name: "ComplaintNumberSequences");

            migrationBuilder.DropTable(
                name: "ComplaintRewards");

            migrationBuilder.DropTable(
                name: "ContactTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "ContactUsEmails");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CountryCodeTableItems");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "DecisionControls");

            migrationBuilder.DropTable(
                name: "EmailAttachments");

            migrationBuilder.DropTable(
                name: "EmailCodeTableItems");

            migrationBuilder.DropTable(
                name: "EmailExecutions");

            migrationBuilder.DropTable(
                name: "EmailQueue");

            migrationBuilder.DropTable(
                name: "FileTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "FootPrintTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "FredRequestFiles");

            migrationBuilder.DropTable(
                name: "GiftCardPayInAdvances");

            migrationBuilder.DropTable(
                name: "MediaTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MobileMoneys");

            migrationBuilder.DropTable(
                name: "NaturalPersonAddresses");

            migrationBuilder.DropTable(
                name: "NaturalPersonSpouses");

            migrationBuilder.DropTable(
                name: "OfficialDiscussion");

            migrationBuilder.DropTable(
                name: "OrderTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "OrganizationAddresses");

            migrationBuilder.DropTable(
                name: "PaymentLogs");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PayPals");

            migrationBuilder.DropTable(
                name: "ProcessingPhases");

            migrationBuilder.DropTable(
                name: "ProvinceCodeTableItems");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Quartiers");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "RoadTypes");

            migrationBuilder.DropTable(
                name: "ServiceTypeCodeTableItems");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ComplaintDrafts");

            migrationBuilder.DropTable(
                name: "ReasonRejecteds");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "FredRequest");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PhysicPeople");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "EnterpriseTypes");

            migrationBuilder.DropTable(
                name: "NaturalPeople");

            migrationBuilder.DropTable(
                name: "OrganizationCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Civilities");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "SpouseType");

            migrationBuilder.DropTable(
                name: "GovernmentOffices");

            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "IncidentCategories");
        }
    }
}
