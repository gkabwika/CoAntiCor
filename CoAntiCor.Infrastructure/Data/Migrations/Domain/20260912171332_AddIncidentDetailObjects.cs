using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoAntiCor.Infrastructure.Data.Migrations.Domain
{
    /// <inheritdoc />
    public partial class AddIncidentDetailObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentDetail_IncidentRequests_IncidentRequestId",
                table: "IncidentDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentDetail",
                table: "IncidentDetail");

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("6458bc8b-8041-420b-9ac9-de9e44341c57"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("8e1517af-cc72-454e-b342-5b8813356691"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("ace29b8a-360e-4368-ac2f-af077ddad48d"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("cb3a14c1-5944-48bc-aead-89ed5c64a25f"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("ddf426c8-55ab-42c5-9376-003cde346563"));

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

            migrationBuilder.RenameTable(
                name: "IncidentDetail",
                newName: "IncidentDetails");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentDetail_IncidentRequestId",
                table: "IncidentDetails",
                newName: "IX_IncidentDetails_IncidentRequestId");

            migrationBuilder.AddColumn<Guid>(
                name: "IncidentRequestId1",
                table: "IncidentSecurityDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStep",
                table: "IncidentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "DraftId",
                table: "IncidentRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "IncidentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentDetails",
                table: "IncidentDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b13ee7b-3b55-4908-aba6-bd11edefc723", "a8d0ce9d-e51d-491e-a557-d3f275902d26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1ced8d8-0d28-42bc-b29a-aea2ea5ddd4b", "cd9f4298-f1f6-4d01-bfb6-3f9b034aec2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "433cd3eb-7c52-4988-9c36-8f2efea92d71", "7b4153f1-6224-49b5-af98-4c027e1d75a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3deba50-df37-4285-80c9-87c2b11c396a", "9c8f43db-31ab-4433-89a7-55cb295f6887" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5933cfbd-e3e7-40c7-9b6d-14abeed94687", "c3a1f6d1-ed2b-4032-9b8d-738ca20ce2d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1768e67b-f809-4706-a8b9-0ea6bfe0f159", "39ffb613-82d8-4cf5-9af7-9cf7c66c9f72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "167253d7-aa2c-471c-a9d4-8b6839f967eb", "0468382c-9c7e-479e-b802-5ec7dafe5961" });

            migrationBuilder.InsertData(
                table: "IncidentDetails",
                columns: new[] { "Id", "Address", "AggressiveBehaviorDescription", "AggressiveBehaviorDuration", "AggressiveBehaviorFrequency", "AggressiveBehaviorObserved", "ApproxAmount", "AttachmentChoice", "AttachmentExplanation", "AttachmentToCorruptionMethods", "City", "Commune", "CorruptionDiscreetlyCompleted", "CorruptionWithConfidence", "CreatedBy", "CreatedDT", "CurrencyType", "DeletedBy", "DeletedDT", "DepartmentInvolved", "DocumentName", "DocumentPath", "EducationLevel", "HasCorruptionStatements", "HasPaidAgentBefore", "HasPrivateOrganizationInvolved", "IncidentCategoryId", "IncidentCategoryName", "IncidentDate", "IncidentRequestId", "IncreasedMotivationOrInterest", "IntimidationObserved", "IsActive", "IsCurrentDocument", "MarkForDelete", "OtherOfficial", "PaymentMadeBefore", "PaymentReasonDescription", "PaymentReasonFrequency", "PaymentReasonType", "PlannedFacts", "PrimaryOfficial", "Province", "Quartier", "ReasonForPayment", "SecondaryOfficial", "SecurityAcknowledged", "SimilarCorruptionExists", "TemperamentOptimism", "UpdatedBy", "UpdatedDT", "VictimDescription", "VictimLifeInDanger", "VictimProvidesName" },
                values: new object[] { new Guid("60000000-0000-0000-0000-000000000001"), null, null, null, null, false, 15000000m, "None", null, false, null, null, true, false, null, null, "CDF", null, null, "Direction Financière", null, null, null, true, false, false, null, null, new DateTime(2026, 8, 28, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2645), new Guid("50000000-0000-0000-0000-000000000001"), false, false, true, false, false, null, false, null, null, null, "Transfert non autorisé", "Chef de Division", null, null, false, "Comptable", true, false, false, null, null, "Le plaignant a observé des transferts suspects.", false, false });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "CurrentStep", "DraftId", "LastUpdatedAt", "ShortDescription", "SubmittedAt", "Version" },
                values: new object[] { new DateTime(2026, 8, 31, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2529), 0, null, new DateTime(2026, 9, 2, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2540), null, new DateTime(2026, 8, 31, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2536), 0 });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "CurrentStep", "DraftId", "LastUpdatedAt", "ShortDescription", "SubmittedAt", "Version" },
                values: new object[] { new DateTime(2026, 8, 23, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2553), 0, null, new DateTime(2026, 8, 28, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2555), null, new DateTime(2026, 8, 23, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2554), 0 });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "CurrentStep", "DraftId", "LastUpdatedAt", "ShortDescription", "SubmittedAt", "Version" },
                values: new object[] { new DateTime(2026, 9, 5, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2566), 0, null, new DateTime(2026, 9, 7, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2567), null, new DateTime(2026, 9, 5, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2567), 0 });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "CurrentStep", "DraftId", "LastUpdatedAt", "ShortDescription", "SubmittedAt", "Version" },
                values: new object[] { new DateTime(2026, 9, 9, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2575), 0, null, new DateTime(2026, 9, 10, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2577), null, new DateTime(2026, 9, 9, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2575), 0 });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "CurrentStep", "DraftId", "LastUpdatedAt", "ShortDescription", "SubmittedAt", "Version" },
                values: new object[] { new DateTime(2026, 8, 29, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2587), 0, null, new DateTime(2026, 8, 31, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2588), null, new DateTime(2026, 8, 29, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2588), 0 });

            migrationBuilder.InsertData(
                table: "IncidentSecurityDetails",
                columns: new[] { "Id", "BlacklistHit", "BrowserName", "BrowserVersion", "CookiesEnabled", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "DeviceId", "DeviceManufacturer", "DeviceModel", "DeviceOS", "DeviceOSVersion", "DuplicateContentDetected", "EntryUrl", "FirstAccessedAtUtc", "GeoAccuracyMeters", "GeoCity", "GeoCountry", "GeoLatitude", "GeoLongitude", "GeoRegion", "HighRiskPatternDetected", "HostingProviderDetected", "IncidentRequestId", "IncidentRequestId1", "InteractionIntervalMs", "IpAddress", "IpAddressOriginCity", "IpAddressOriginCountry", "IpAddressOriginISP", "IsActive", "IsBotSuspected", "IsMobileDevice", "JavascriptEnabled", "Language", "LastAccessedAtUtc", "LocalStorageEnabled", "MarkForDelete", "MouseMovementPatternHash", "NetworkType", "Platform", "ProxyDetected", "ReferrerUrl", "RepeatedSubmissionDetected", "RiskLevel", "RiskScore", "ScreenResolution", "SessionDurationSeconds", "SessionId", "SessionReused", "SubmissionAttemptCount", "SubmissionCompletedAtUtc", "SuspiciousInteractionScore", "TimezoneOffset", "TorDetected", "TouchPressurePatternHash", "TypingSpeedWPM", "UpdatedBy", "UpdatedDT", "UserAgentString", "VpnDetected", "WhitelistHit" },
                values: new object[,]
                {
                    { new Guid("03df61a6-d7ba-4f4a-87f8-7bde3f5882fb"), false, "Chrome", "125.0", true, null, null, null, null, "dev-wifi-22", "Huawei", "Huawei P30", "Android", "12", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 12, 16, 43, 30, 914, DateTimeKind.Utc).AddTicks(2844), 1500.0, "Ottawa", "Canada", 45.420999999999999, -75.697000000000003, "Ontario", true, false, new Guid("51000000-0000-0000-0000-000000000005"), null, 210.0, "172.16.0.22", "Ottawa", "Canada", "Public WiFi", true, false, true, true, "fr-CA", new DateTime(2026, 9, 12, 17, 13, 30, 914, DateTimeKind.Utc).AddTicks(2845), true, false, null, "Public WiFi", "Android", true, "", true, "High", 78, "1080x2340", 1800, "sess-wifi-22", true, 3, null, 65, -240, false, "tp-5511", 38.0, null, null, "Mozilla/5.0 (Linux; Android 12; ELE-L29)...", false, false },
                    { new Guid("1e0dcbd1-6bae-460f-98c4-69c09d5706b5"), false, "Edge", "126.0", true, null, null, null, null, "dev-corp-77", "Dell", "Dell Latitude 7420", "Windows", "11 Pro", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 12, 16, 13, 30, 914, DateTimeKind.Utc).AddTicks(2820), 300.0, "Toronto", "Canada", 43.652999999999999, -79.382999999999996, "Ontario", false, false, new Guid("51000000-0000-0000-0000-000000000003"), null, 320.0, "64.18.12.44", "Toronto", "Canada", "Bell Canada", true, false, false, true, "en-CA", new DateTime(2026, 9, 12, 17, 13, 30, 914, DateTimeKind.Utc).AddTicks(2821), true, false, "mm-9921", "Corporate", "Windows", false, "", false, "Low", 5, "1920x1080", 3600, "sess-corp-77", false, 1, null, 10, -240, false, null, 72.0, null, null, "Mozilla/5.0 (Windows NT 10.0; Win64; x64)...", false, true },
                    { new Guid("2bd24919-7915-4cd3-b215-e96376cc71a9"), true, "Tor Browser", "13.0", false, null, null, null, null, "dev-tor-001", "Unknown", "Unknown", "Linux", "Unknown", true, "https://anti-corruption.gov/report", new DateTime(2026, 9, 12, 17, 8, 30, 914, DateTimeKind.Utc).AddTicks(2808), null, "Unknown", "Unknown", null, null, "Unknown", true, true, new Guid("51000000-0000-0000-0000-000000000002"), null, 50.0, "185.220.100.255", "Unknown", "Unknown", "Tor Exit Node", true, true, false, false, "en-US", new DateTime(2026, 9, 12, 17, 13, 30, 914, DateTimeKind.Utc).AddTicks(2809), false, false, "mm-0000", "Tor", "Linux", true, "", true, "Critical", 95, "1920x1080", 300, "sess-tor-001", true, 7, null, 88, 0, true, null, 12.0, null, null, "Mozilla/5.0 (X11; Linux x86_64; rv:102.0)...", false, false },
                    { new Guid("9eb87d05-dc03-4467-a272-1bd28493bb32"), false, "Chrome", "126.0", true, null, null, null, null, "dev-7c1f8e", "Samsung", "Samsung Galaxy S22", "Android", "14", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 12, 15, 13, 30, 914, DateTimeKind.Utc).AddTicks(2795), 5000.0, "Berlin", "Germany", 52.520000000000003, 13.404999999999999, "Berlin", false, true, new Guid("50000000-0000-0000-0000-000000000001"), null, 190.0, "185.220.101.4", "Berlin", "Germany", "M247 Ltd", true, false, true, true, "en-US", new DateTime(2026, 9, 12, 17, 13, 30, 914, DateTimeKind.Utc).AddTicks(2797), true, false, null, "VPN", "Android", false, "", true, "Medium", 42, "1080x2340", 7200, "sess-9f8d1e", true, 4, null, 35, 120, false, "tp-9921aa", 55.0, null, null, "Mozilla/5.0 (Linux; Android 14; SM-S901W)...", true, false },
                    { new Guid("ae1ea5ad-2c0e-4a4d-8201-b0f8fd6a91cf"), false, "Safari", "17.0", true, null, null, null, null, "dev-9f2a1c", "Apple", "iPhone 13", "iOS", "17.2", false, "https://anti-corruption.gov/report", new DateTime(2026, 9, 12, 16, 58, 30, 914, DateTimeKind.Utc).AddTicks(2771), 120.0, "Whitby", "Canada", 43.896999999999998, -78.941999999999993, "Ontario", false, false, new Guid("51000000-0000-0000-0000-000000000004"), null, 280.0, "24.48.102.91", "Whitby", "Canada", "Rogers Communications", true, false, true, true, "fr-CA", new DateTime(2026, 9, 12, 17, 13, 30, 914, DateTimeKind.Utc).AddTicks(2777), true, false, null, "Home", "iOS", false, "", false, "Low", 8, "1170x2532", 900, "sess-1a2b3c", false, 1, null, 12, -240, false, "tp-3929ab", 42.0, null, null, "Mozilla/5.0 (iPhone; CPU iPhone OS 17_2 like Mac OS X)...", false, true }
                });

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 9, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 10, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 11, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 12, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.InsertData(
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("37bd7185-56b0-4a59-a774-66fba5dbed93"), new DateTime(2026, 9, 11, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(3063), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("ae819780-94bb-409a-93d3-d7f5f12bbd0d"), new DateTime(2026, 9, 10, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(3060), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null },
                    { new Guid("d3acd46a-3698-438c-b7e6-d2eada0fb02c"), new DateTime(2026, 9, 9, 17, 13, 30, 922, DateTimeKind.Utc).AddTicks(3052), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentSecurityDetails_IncidentRequestId1",
                table: "IncidentSecurityDetails",
                column: "IncidentRequestId1",
                unique: true,
                filter: "[IncidentRequestId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentDetails_IncidentRequests_IncidentRequestId",
                table: "IncidentDetails",
                column: "IncidentRequestId",
                principalTable: "IncidentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentSecurityDetails_IncidentRequests_IncidentRequestId1",
                table: "IncidentSecurityDetails",
                column: "IncidentRequestId1",
                principalTable: "IncidentRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentDetails_IncidentRequests_IncidentRequestId",
                table: "IncidentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentSecurityDetails_IncidentRequests_IncidentRequestId1",
                table: "IncidentSecurityDetails");

            migrationBuilder.DropIndex(
                name: "IX_IncidentSecurityDetails_IncidentRequestId1",
                table: "IncidentSecurityDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentDetails",
                table: "IncidentDetails");

            migrationBuilder.DeleteData(
                table: "IncidentDetails",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("03df61a6-d7ba-4f4a-87f8-7bde3f5882fb"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("1e0dcbd1-6bae-460f-98c4-69c09d5706b5"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("2bd24919-7915-4cd3-b215-e96376cc71a9"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("9eb87d05-dc03-4467-a272-1bd28493bb32"));

            migrationBuilder.DeleteData(
                table: "IncidentSecurityDetails",
                keyColumn: "Id",
                keyValue: new Guid("ae1ea5ad-2c0e-4a4d-8201-b0f8fd6a91cf"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("37bd7185-56b0-4a59-a774-66fba5dbed93"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("ae819780-94bb-409a-93d3-d7f5f12bbd0d"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("d3acd46a-3698-438c-b7e6-d2eada0fb02c"));

            migrationBuilder.DropColumn(
                name: "IncidentRequestId1",
                table: "IncidentSecurityDetails");

            migrationBuilder.DropColumn(
                name: "CurrentStep",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "DraftId",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "IncidentRequests");

            migrationBuilder.RenameTable(
                name: "IncidentDetails",
                newName: "IncidentDetail");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentDetails_IncidentRequestId",
                table: "IncidentDetail",
                newName: "IX_IncidentDetail_IncidentRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentDetail",
                table: "IncidentDetail",
                column: "Id");

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
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6574), new DateTime(2026, 8, 30, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6588), new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6584) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 20, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6608), new DateTime(2026, 8, 25, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6612), new DateTime(2026, 8, 20, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 2, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6625), new DateTime(2026, 9, 4, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6627), new DateTime(2026, 9, 2, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6747), new DateTime(2026, 9, 7, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 9, 6, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 26, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6763), new DateTime(2026, 8, 28, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6765), new DateTime(2026, 8, 26, 22, 11, 30, 573, DateTimeKind.Utc).AddTicks(6764) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentDetail_IncidentRequests_IncidentRequestId",
                table: "IncidentDetail",
                column: "IncidentRequestId",
                principalTable: "IncidentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
