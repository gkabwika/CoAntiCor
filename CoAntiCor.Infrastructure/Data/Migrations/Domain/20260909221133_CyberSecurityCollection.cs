using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoAntiCor.Infrastructure.Data.Migrations.Domain
{
    /// <inheritdoc />
    public partial class CyberSecurityCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("97b8df5d-f031-4781-b76d-2c622764bd6e"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("c68eb3b1-d0cc-4f03-a6af-9f57aeb2e8d5"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("eff987d9-f40d-4ff2-90cb-5b1732f95349"));

            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IncidentSecurityDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeviceManufacturer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeviceOS = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DeviceOSVersion = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    BrowserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserAgentString = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ScreenResolution = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IsMobileDevice = table.Column<bool>(type: "bit", nullable: false),
                    IsBotSuspected = table.Column<bool>(type: "bit", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    IpAddressOriginCountry = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IpAddressOriginCity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IpAddressOriginISP = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    VpnDetected = table.Column<bool>(type: "bit", nullable: false),
                    ProxyDetected = table.Column<bool>(type: "bit", nullable: false),
                    TorDetected = table.Column<bool>(type: "bit", nullable: false),
                    HostingProviderDetected = table.Column<bool>(type: "bit", nullable: false),
                    NetworkType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    GeoLatitude = table.Column<double>(type: "float", nullable: true),
                    GeoLongitude = table.Column<double>(type: "float", nullable: true),
                    GeoAccuracyMeters = table.Column<double>(type: "float", nullable: true),
                    GeoCountry = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GeoCity = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    GeoRegion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    TypingSpeedWPM = table.Column<double>(type: "float", nullable: true),
                    MouseMovementPatternHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TouchPressurePatternHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InteractionIntervalMs = table.Column<double>(type: "float", nullable: true),
                    SuspiciousInteractionScore = table.Column<int>(type: "int", nullable: false),
                    FirstAccessedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionAttemptCount = table.Column<int>(type: "int", nullable: false),
                    SubmissionCompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionDurationSeconds = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SessionReused = table.Column<bool>(type: "bit", nullable: false),
                    RepeatedSubmissionDetected = table.Column<bool>(type: "bit", nullable: false),
                    DuplicateContentDetected = table.Column<bool>(type: "bit", nullable: false),
                    HighRiskPatternDetected = table.Column<bool>(type: "bit", nullable: false),
                    BlacklistHit = table.Column<bool>(type: "bit", nullable: false),
                    WhitelistHit = table.Column<bool>(type: "bit", nullable: false),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    RiskLevel = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    JavascriptEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CookiesEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LocalStorageEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TimezoneOffset = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReferrerUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    EntryUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
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
                    table.PrimaryKey("PK_IncidentSecurityDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentSecurityDetails_IncidentRequests_IncidentRequestId",
                        column: x => x.IncidentRequestId,
                        principalTable: "IncidentRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ccec78c-e6ed-4e7d-948a-64d7acffad87", "8504805c-1ea7-44ac-b614-a1590e2160f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8205233-b2bc-4e52-83e4-168421a9c3ef", "206193f1-7cb9-49ae-8f67-b41ca4db8b77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22a939b7-fe41-4a62-9ab0-fb65f1198f75", "64ad79c8-c026-4d58-ab7c-f7596fd8f3c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce86d867-aadc-4df5-b1b2-71601aea0428", "c8dca5c7-b81d-44a3-b7e3-869044be8044" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5e02f55f-1278-456b-bad9-b85afa4fbc94", "045ff7e0-defe-42c2-b6e3-b961893290a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c517e608-708c-4f18-bd42-d0c827c53820", "a4852231-7c16-4482-96f6-6b1083309f84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62ae8a84-d731-421d-9861-1a1c367f4682", "8b882724-8ecf-4c20-aaa0-6bca4e0933c7" });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "AccessCode", "CreatedAt", "LastUpdatedAt", "ReferenceNumber", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6574), new DateTime(2026, 8, 30, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6588), null, new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6584) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "AccessCode", "CreatedAt", "LastUpdatedAt", "ReferenceNumber", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 20, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6608), new DateTime(2026, 8, 25, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6612), null, new DateTime(2026, 8, 20, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "AccessCode", "CreatedAt", "LastUpdatedAt", "ReferenceNumber", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 9, 2, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6625), new DateTime(2026, 9, 4, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6627), null, new DateTime(2026, 9, 2, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "AccessCode", "CreatedAt", "LastUpdatedAt", "ReferenceNumber", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6747), new DateTime(2026, 9, 7, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6750), null, new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "AccessCode", "CreatedAt", "LastUpdatedAt", "ReferenceNumber", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 26, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6763), new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6765), null, new DateTime(2026, 8, 26, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6764) });

            migrationBuilder.InsertData(
                table: "IncidentSecurityDetails",
                columns: new[] { "Id", "BlacklistHit", "BrowserName", "BrowserVersion", "CookiesEnabled", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "DeviceId", "DeviceManufacturer", "DeviceModel", "DeviceOS", "DeviceOSVersion", "DuplicateContentDetected", "EntryUrl", "FirstAccessedAtUtc", "GeoAccuracyMeters", "GeoCity", "GeoCountry", "GeoLatitude", "GeoLongitude", "GeoRegion", "HighRiskPatternDetected", "HostingProviderDetected", "IncidentRequestId", "InteractionIntervalMs", "IpAddress", "IpAddressOriginCity", "IpAddressOriginCountry", "IpAddressOriginISP", "IsActive", "IsBotSuspected", "IsMobileDevice", "JavascriptEnabled", "Language", "LastAccessedAtUtc", "LocalStorageEnabled", "MarkForDelete", "MouseMovementPatternHash", "NetworkType", "Platform", "ProxyDetected", "ReferrerUrl", "RepeatedSubmissionDetected", "RiskLevel", "RiskScore", "ScreenResolution", "SessionDurationSeconds", "SessionId", "SessionReused", "SubmissionAttemptCount", "SubmissionCompletedAtUtc", "SuspiciousInteractionScore", "TimezoneOffset", "TorDetected", "TouchPressurePatternHash", "TypingSpeedWPM", "UpdatedBy", "UpdatedDT", "UserAgentString", "VpnDetected", "WhitelistHit" },
                values: new object[,]
                {
                    { new Guid("6458bc8b-8041-420b-9ac9-de9e44341c57"), false, "Safari", "17.0", true, null, null, null, null, "dev-9f2a1c", "Apple", "iPhone 13", "iOS", "17.2", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 9, 21, 56, 30, 557, DateTimeKind.Utc).AddTicks(4280), 120.0, "Whitby", "Canada", 43.896999999999998, -78.941999999999993, "Ontario", false, false, new Guid("51000000-0000-0000-0000-000000000004"), 280.0, "24.48.102.91", "Whitby", "Canada", "Rogers Communications", true, false, true, true, "fr-CA", new DateTime(2026, 9, 9, 22, 11, 30, 557, DateTimeKind.Utc).AddTicks(4290), true, false, null, "Home", "iOS", false, "", false, "Low", 8, "1170x2532", 900, "sess-1a2b3c", false, 1, null, 12, -240, false, "tp-3929ab", 42.0, null, null, "Mozilla/5.0 (iPhone; CPU iPhone OS 17_2 like Mac OS X)...", false, true },
                    { new Guid("8e1517af-cc72-454e-b342-5b8813356691"), true, "Tor Browser", "13.0", false, null, null, null, null, "dev-tor-001", "Unknown", "Unknown", "Linux", "Unknown", true, "https://anti-corruption.gov/report", new DateTime(2026, 9, 9, 22, 6, 30, 557, DateTimeKind.Utc).AddTicks(4404), null, "Unknown", "Unknown", null, null, "Unknown", true, true, new Guid("51000000-0000-0000-0000-000000000002"), 50.0, "185.220.100.255", "Unknown", "Unknown", "Tor Exit Node", true, true, false, false, "en-US", new DateTime(2026, 9, 9, 22, 11, 30, 557, DateTimeKind.Utc).AddTicks(4406), false, false, "mm-0000", "Tor", "Linux", true, "", true, "Critical", 95, "1920x1080", 300, "sess-tor-001", true, 7, null, 88, 0, true, null, 12.0, null, null, "Mozilla/5.0 (X11; Linux x86_64; rv:102.0)...", false, false },
                    { new Guid("ace29b8a-360e-4368-ac2f-af077ddad48d"), false, "Chrome", "125.0", true, null, null, null, null, "dev-wifi-22", "Huawei", "Huawei P30", "Android", "12", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 9, 21, 41, 30, 557, DateTimeKind.Utc).AddTicks(4831), 1500.0, "Ottawa", "Canada", 45.420999999999999, -75.697000000000003, "Ontario", true, false, new Guid("51000000-0000-0000-0000-000000000005"), 210.0, "172.16.0.22", "Ottawa", "Canada", "Public WiFi", true, false, true, true, "fr-CA", new DateTime(2026, 9, 9, 22, 11, 30, 557, DateTimeKind.Utc).AddTicks(4834), true, false, null, "Public WiFi", "Android", true, "", true, "High", 78, "1080x2340", 1800, "sess-wifi-22", true, 3, null, 65, -240, false, "tp-5511", 38.0, null, null, "Mozilla/5.0 (Linux; Android 12; ELE-L29)...", false, false },
                    { new Guid("cb3a14c1-5944-48bc-aead-89ed5c64a25f"), false, "Edge", "126.0", true, null, null, null, null, "dev-corp-77", "Dell", "Dell Latitude 7420", "Windows", "11 Pro", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 9, 21, 11, 30, 557, DateTimeKind.Utc).AddTicks(4434), 300.0, "Toronto", "Canada", 43.652999999999999, -79.382999999999996, "Ontario", false, false, new Guid("51000000-0000-0000-0000-000000000003"), 320.0, "64.18.12.44", "Toronto", "Canada", "Bell Canada", true, false, false, true, "en-CA", new DateTime(2026, 9, 9, 22, 11, 30, 557, DateTimeKind.Utc).AddTicks(4437), true, false, "mm-9921", "Corporate", "Windows", false, "", false, "Low", 5, "1920x1080", 3600, "sess-corp-77", false, 1, null, 10, -240, false, null, 72.0, null, null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)...", false, true },
                    { new Guid("ddf426c8-55ab-42c5-9376-003cde346563"), false, "Chrome", "126.0", true, null, null, null, null, "dev-7c1f8e", "Samsung", "Samsung Galaxy S22", "Android", "14", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 9, 20, 11, 30, 557, DateTimeKind.Utc).AddTicks(4366), 5000.0, "Berlin", "Germany", 52.520000000000003, 13.404999999999999, "Berlin", false, true, new Guid("50000000-0000-0000-0000-000000000001"), 190.0, "185.220.101.4", "Berlin", "Germany", "M247 Ltd", true, false, true, true, "en-US", new DateTime(2026, 9, 9, 22, 11, 30, 557, DateTimeKind.Utc).AddTicks(4372), true, false, null, "VPN", "Android", false, "", true, "Medium", 42, "1080x2340", 7200, "sess-9f8d1e", true, 4, null, 35, 120, false, "tp-9921aa", 55.0, null, null, "Mozilla/5.0 (Linux; Android 14; SM-S901W)...", true, false }
                });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "TitleFrench" },
                values: new object[] { "Report an incident", "Signaler un incident" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Track My Incident");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Contact us");

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 7, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 8, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 9, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6950));

            migrationBuilder.InsertData(
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("6a6364d9-2cfa-45f8-8bb3-bf6fc48f7be0"), new DateTime(2026, 9, 8, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(7415), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("9c2c0da9-526f-4367-8dca-7c5d26119d38"), new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(7403), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null },
                    { new Guid("b8f55bda-2b20-4203-93e3-498a8b6cf56b"), new DateTime(2026, 9, 7, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(7411), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentSecurityDetails_IncidentRequestId",
                table: "IncidentSecurityDetails",
                column: "IncidentRequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentSecurityDetails");

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("6a6364d9-2cfa-45f8-8bb3-bf6fc48f7be0"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("9c2c0da9-526f-4367-8dca-7c5d26119d38"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("b8f55bda-2b20-4203-93e3-498a8b6cf56b"));

            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "IncidentRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1959bd8f-07bd-41d1-858a-dd0e4bf67131", "a1603259-1d4f-4b57-87b2-548e4ffd4089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d7035e4-d0ca-46f9-a248-dc7ab58da925", "c6b033f6-fee2-497d-9b0f-6718c5509905" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "95bb64b6-9493-4e10-bb3b-d991bfba1047", "1290444f-7d4a-470e-b284-9e74887aff1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "088e4386-6830-4a0d-b7f9-4c04f5fbb313", "84b92ae7-da4e-4bfa-a7ea-5a3f2cf2fd78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5f1703f-0725-4d3b-b8f3-c2c89e887250", "8783cf92-6a4b-491b-b6ed-18b11638f5b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0416d010-9424-47b3-a131-c6f50a703161", "2ff58d71-d397-4bb3-9b97-2e79adc43c92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5413c263-10ff-44d6-b38f-23bf27c1094e", "f01a66c1-2ecf-4d6f-acc6-bc9d5f87261c" });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8484), new DateTime(2026, 8, 30, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8496), new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 20, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8512), new DateTime(2026, 8, 25, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8514), new DateTime(2026, 8, 20, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 2, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 9, 4, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8530), new DateTime(2026, 9, 2, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8541), new DateTime(2026, 9, 7, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8543), new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 26, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8604), new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8606), new DateTime(2026, 8, 26, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Title", "TitleFrench" },
                values: new object[] { "Report a Complaint", "Signaler une plainte" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Track My Complaint");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Contact");

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 7, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 8, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 9, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.InsertData(
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("97b8df5d-f031-4781-b76d-2c622764bd6e"), new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(9009), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null },
                    { new Guid("c68eb3b1-d0cc-4f03-a6af-9f57aeb2e8d5"), new DateTime(2026, 9, 8, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(9017), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("eff987d9-f40d-4ff2-90cb-5b1732f95349"), new DateTime(2026, 9, 7, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(9013), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null }
                });
        }
    }
}
