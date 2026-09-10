using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoAntiCor.Infrastructure.Data.Migrations.Domain
{
    /// <inheritdoc />
    public partial class UserRolesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("2063c074-2729-4afc-af76-d48ccdc4611d"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("2dedc7f3-f2d7-45a5-a3d2-1da615a24c4e"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("4d92bc83-763c-413a-b538-e775806abeb5"));

            migrationBuilder.AlterColumn<string>(
                name: "LabelFr",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LabelEn",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroup",
                table: "ServiceRequestWorkflowStates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgeGroups",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityChoice",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobRole",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterFullName",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7fb3bdc-338c-4768-b46b-050ee1f304c8", "4256c0e2-5277-4728-b50d-3ebf180332f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9c489d05-486e-49f8-a255-9962f3aa06ed", "9cf8f339-a207-4893-abee-7f0514c5a58a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9432d65-0618-4a5e-a10b-13802e6f6cac", "314357a7-0db8-41c7-99b8-2fa8525a2448" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "710aff7f-612f-4685-85c1-052fe0da4158", "2961fc4b-fe5b-4138-ae25-68d4e3b0380d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d28ccb2-3b02-4a9a-84d0-8d63123e59e4", "5d899ceb-b183-4805-90f4-e03c1885bc0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47661487-adb1-4ae0-90db-2ac33858dd9d", "545445a4-d60d-4477-a063-a83370d50bb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38dc3c42-84aa-4357-b27b-589d51b4c426", "dc9b34c0-1147-4031-b587-34019b239e66" });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 27, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 8, 29, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2123), new DateTime(2026, 8, 27, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2118) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 19, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2145), new DateTime(2026, 8, 24, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2147), new DateTime(2026, 8, 19, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 1, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2166), new DateTime(2026, 9, 3, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2169), new DateTime(2026, 9, 1, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2167) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 5, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2182), new DateTime(2026, 9, 6, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2184), new DateTime(2026, 9, 5, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 25, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2204), new DateTime(2026, 8, 27, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2207), new DateTime(2026, 8, 25, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Title", "TitleFrench", "Url" },
                values: new object[] { "Incidents", "Incidents", "/internal/incidents" });

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 5, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 6, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 7, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 8, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11121111-2422-1111-3333-111117111111"), "SuperUser" },
                    { new Guid("22212222-4444-2222-3333-222272622222"), "CitizenOnly" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("85e30bd7-b17d-4ce5-a996-d74d51e4d417"), new DateTime(2026, 9, 7, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3170), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("a4b245dd-c811-4437-ab0d-e1b01b27b1dc"), new DateTime(2026, 9, 5, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3158), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null },
                    { new Guid("ec5fe323-7d6b-42e1-8805-cc8acb50b517"), new DateTime(2026, 9, 6, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3166), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null }
                });

            migrationBuilder.UpdateData(
                table: "ServiceRequestWorkflowStates",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                columns: new[] { "AgeGroup", "AgeGroups", "IdentityChoice", "JobRole", "ReporterFullName", "Service", "Sex" },
                values: new object[] { null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ServiceRequestWorkflowStates",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                columns: new[] { "AgeGroup", "AgeGroups", "IdentityChoice", "JobRole", "ReporterFullName", "Service", "Sex" },
                values: new object[] { null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ServiceRequestWorkflowStates",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                columns: new[] { "AgeGroup", "AgeGroups", "IdentityChoice", "JobRole", "ReporterFullName", "Service", "Sex" },
                values: new object[] { null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ServiceRequestWorkflowStates",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                columns: new[] { "AgeGroup", "AgeGroups", "IdentityChoice", "JobRole", "ReporterFullName", "Service", "Sex" },
                values: new object[] { null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ServiceRequestWorkflowStates",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                columns: new[] { "AgeGroup", "AgeGroups", "IdentityChoice", "JobRole", "ReporterFullName", "Service", "Sex" },
                values: new object[] { null, null, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestWorkflowStates_Code",
                table: "ServiceRequestWorkflowStates",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestWorkflowStates_DraftId",
                table: "ServiceRequestWorkflowStates",
                column: "DraftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestWorkflowStates_Code",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequestWorkflowStates_DraftId",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11121111-2422-1111-3333-111117111111"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22212222-4444-2222-3333-222272622222"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("85e30bd7-b17d-4ce5-a996-d74d51e4d417"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("a4b245dd-c811-4437-ab0d-e1b01b27b1dc"));

            migrationBuilder.DeleteData(
                table: "ServiceRequestHistorys",
                keyColumn: "Id",
                keyValue: new Guid("ec5fe323-7d6b-42e1-8805-cc8acb50b517"));

            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "AgeGroups",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "IdentityChoice",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "JobRole",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "ReporterFullName",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "ServiceRequestWorkflowStates");

            migrationBuilder.AlterColumn<string>(
                name: "LabelFr",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LabelEn",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ServiceRequestWorkflowStates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e7cc923a-bfc3-41a5-a806-13287363f2a3", "99c46ce9-8b02-41ea-adcd-d446616ec203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "158a2a7f-52dd-438b-b0a2-a6beaa52be8f", "4d426e3f-ff2f-40fd-b964-5699ae513ae0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "345adbca-e4cd-4ebc-999c-f10a66c23661", "90ebeba8-b6d5-4c74-b5f2-dc2a688ad16e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c2b72530-a4ff-4655-8ddf-d505f324ae3e", "4a42f750-39ee-4aba-8be3-81e833a08903" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41736ea3-4e90-405c-9e33-aa17982e3318", "47d39655-3989-46c7-ad4c-3aa50cdc5bb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000006",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3142dc1f-3f0c-4a8d-9b37-ebf2226f843a", "2c30bf1f-ebcd-4cec-86f5-efc289f19369" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90000000-0000-0000-0000-000000000007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "008e450b-f173-4ac8-a7f9-d5d7605dfb6c", "b487b3e7-9e76-47b4-8a9f-56ba865c83d9" });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 26, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(203), new DateTime(2026, 8, 28, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(333), new DateTime(2026, 8, 26, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 18, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(361), new DateTime(2026, 8, 23, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(363), new DateTime(2026, 8, 18, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 31, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(377), new DateTime(2026, 9, 2, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(379), new DateTime(2026, 8, 31, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(378) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 9, 4, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(391), new DateTime(2026, 9, 5, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(393), new DateTime(2026, 9, 4, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(392) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "SubmittedAt" },
                values: new object[] { new DateTime(2026, 8, 24, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(405), new DateTime(2026, 8, 26, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(407), new DateTime(2026, 8, 24, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(405) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Title", "TitleFrench", "Url" },
                values: new object[] { "Complaints", "Plaintes", "/internal/complaints" });

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 4, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 5, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 6, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "ProcessingPhaseHistory",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000004"),
                column: "ChangedAt",
                value: new DateTime(2026, 9, 7, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.InsertData(
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("2063c074-2729-4afc-af76-d48ccdc4611d"), new DateTime(2026, 9, 6, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(1268), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("2dedc7f3-f2d7-45a5-a3d2-1da615a24c4e"), new DateTime(2026, 9, 5, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(1258), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null },
                    { new Guid("4d92bc83-763c-413a-b538-e775806abeb5"), new DateTime(2026, 9, 4, 23, 35, 9, 55, DateTimeKind.Utc).AddTicks(1245), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null }
                });
        }
    }
}
