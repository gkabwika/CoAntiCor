using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoAntiCor.Infrastructure.Data.Migrations.Domain
{
    /// <inheritdoc />
    public partial class IncidentDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsAssistantPerson",
                table: "NaturalPeople",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReporterWitness",
                table: "NaturalPeople",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IncidentDate",
                table: "IncidentRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentDay",
                table: "IncidentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentMonth",
                table: "IncidentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentYear",
                table: "IncidentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCell",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneOffice",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceId",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReporterDateOfBirth",
                table: "IncidentRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterDisplayName",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterOccupation",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterSchoolLevel",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterTitle",
                table: "IncidentRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AuthenticFile",
                table: "IncidentEvidence",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "IncidentEvidence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileTitle",
                table: "IncidentEvidence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OriginalDocument",
                table: "AttachmentDraftItem",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IncidentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncidentCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VictimProvidesName = table.Column<bool>(type: "bit", nullable: false),
                    VictimDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quartier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPrivateOrganizationInvolved = table.Column<bool>(type: "bit", nullable: false),
                    HasCorruptionStatements = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentInvolved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedFacts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryOfficial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryOfficial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherOfficial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VictimLifeInDanger = table.Column<bool>(type: "bit", nullable: false),
                    ReasonForPayment = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMadeBefore = table.Column<bool>(type: "bit", nullable: false),
                    AggressiveBehaviorObserved = table.Column<bool>(type: "bit", nullable: false),
                    IncreasedMotivationOrInterest = table.Column<bool>(type: "bit", nullable: false),
                    IntimidationObserved = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReasonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentReasonFrequency = table.Column<int>(type: "int", nullable: true),
                    AggressiveBehaviorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AggressiveBehaviorDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AggressiveBehaviorFrequency = table.Column<int>(type: "int", nullable: true),
                    TemperamentOptimism = table.Column<bool>(type: "bit", nullable: false),
                    CorruptionDiscreetlyCompleted = table.Column<bool>(type: "bit", nullable: false),
                    HasPaidAgentBefore = table.Column<bool>(type: "bit", nullable: false),
                    CorruptionWithConfidence = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentToCorruptionMethods = table.Column<bool>(type: "bit", nullable: false),
                    SimilarCorruptionExists = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentExplanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentChoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCurrentDocument = table.Column<bool>(type: "bit", nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityAcknowledged = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_IncidentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentDetail_IncidentRequests_IncidentRequestId",
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
                columns: new[] { "CountryCode", "CreatedAt", "Email", "IncidentDate", "IncidentDay", "IncidentMonth", "IncidentYear", "LastUpdatedAt", "Phone", "PhoneCell", "PhoneOffice", "ProvinceId", "ReporterDateOfBirth", "ReporterDisplayName", "ReporterOccupation", "ReporterSchoolLevel", "ReporterTitle", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8484), null, null, null, null, null, new DateTime(2026, 8, 30, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8496), null, null, null, null, null, null, null, null, null, new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000002"),
                columns: new[] { "CountryCode", "CreatedAt", "Email", "IncidentDate", "IncidentDay", "IncidentMonth", "IncidentYear", "LastUpdatedAt", "Phone", "PhoneCell", "PhoneOffice", "ProvinceId", "ReporterDateOfBirth", "ReporterDisplayName", "ReporterOccupation", "ReporterSchoolLevel", "ReporterTitle", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 20, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8512), null, null, null, null, null, new DateTime(2026, 8, 25, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8514), null, null, null, null, null, null, null, null, null, new DateTime(2026, 8, 20, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000003"),
                columns: new[] { "CountryCode", "CreatedAt", "Email", "IncidentDate", "IncidentDay", "IncidentMonth", "IncidentYear", "LastUpdatedAt", "Phone", "PhoneCell", "PhoneOffice", "ProvinceId", "ReporterDateOfBirth", "ReporterDisplayName", "ReporterOccupation", "ReporterSchoolLevel", "ReporterTitle", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 9, 2, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8528), null, null, null, null, null, new DateTime(2026, 9, 4, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8530), null, null, null, null, null, null, null, null, null, new DateTime(2026, 9, 2, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000004"),
                columns: new[] { "CountryCode", "CreatedAt", "Email", "IncidentDate", "IncidentDay", "IncidentMonth", "IncidentYear", "LastUpdatedAt", "Phone", "PhoneCell", "PhoneOffice", "ProvinceId", "ReporterDateOfBirth", "ReporterDisplayName", "ReporterOccupation", "ReporterSchoolLevel", "ReporterTitle", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8541), null, null, null, null, null, new DateTime(2026, 9, 7, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8543), null, null, null, null, null, null, null, null, null, new DateTime(2026, 9, 6, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "IncidentRequests",
                keyColumn: "Id",
                keyValue: new Guid("51000000-0000-0000-0000-000000000005"),
                columns: new[] { "CountryCode", "CreatedAt", "Email", "IncidentDate", "IncidentDay", "IncidentMonth", "IncidentYear", "LastUpdatedAt", "Phone", "PhoneCell", "PhoneOffice", "ProvinceId", "ReporterDateOfBirth", "ReporterDisplayName", "ReporterOccupation", "ReporterSchoolLevel", "ReporterTitle", "SubmittedAt" },
                values: new object[] { null, new DateTime(2026, 8, 26, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8604), null, null, null, null, null, new DateTime(2026, 8, 28, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8606), null, null, null, null, null, null, null, null, null, new DateTime(2026, 8, 26, 3, 16, 26, 666, DateTimeKind.Utc).AddTicks(8605) });

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

            migrationBuilder.CreateIndex(
                name: "IX_IncidentDetail_IncidentRequestId",
                table: "IncidentDetail",
                column: "IncidentRequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentDetail");

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

            migrationBuilder.DropColumn(
                name: "IsAssistantPerson",
                table: "NaturalPeople");

            migrationBuilder.DropColumn(
                name: "IsReporterWitness",
                table: "NaturalPeople");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "IncidentDate",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "IncidentDay",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "IncidentMonth",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "IncidentYear",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "PhoneCell",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "PhoneOffice",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReporterDateOfBirth",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReporterDisplayName",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReporterOccupation",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReporterSchoolLevel",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "ReporterTitle",
                table: "IncidentRequests");

            migrationBuilder.DropColumn(
                name: "AuthenticFile",
                table: "IncidentEvidence");

            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "IncidentEvidence");

            migrationBuilder.DropColumn(
                name: "FileTitle",
                table: "IncidentEvidence");

            migrationBuilder.DropColumn(
                name: "OriginalDocument",
                table: "AttachmentDraftItem");

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
                table: "ServiceRequestHistorys",
                columns: new[] { "Id", "ChangedAt", "ChangedByUserId", "CreatedBy", "CreatedDT", "DeletedBy", "DeletedDT", "IncidentId", "IsActive", "MarkForDelete", "Notes", "Phase", "Status", "UpdatedBy", "UpdatedDT" },
                values: new object[,]
                {
                    { new Guid("85e30bd7-b17d-4ce5-a996-d74d51e4d417"), new DateTime(2026, 9, 7, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3170), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Investigation started by inspector.", "INVESTIGATION", "InProgress", null, null },
                    { new Guid("a4b245dd-c811-4437-ab0d-e1b01b27b1dc"), new DateTime(2026, 9, 5, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3158), null, null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Citizen submitted the incident with initial evidence.", "SUBMITTED", "Submitted", null, null },
                    { new Guid("ec5fe323-7d6b-42e1-8805-cc8acb50b517"), new DateTime(2026, 9, 6, 22, 2, 34, 302, DateTimeKind.Utc).AddTicks(3166), new Guid("10000000-0000-0000-0000-000000000001"), null, null, null, null, new Guid("30000000-0000-0000-0000-000000000001"), true, false, "Initial screening completed. More evidence required.", "SCREENING", "InReview", null, null }
                });
        }
    }
}
