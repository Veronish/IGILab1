using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab1core.Migrations
{
    public partial class lab1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    InspectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InspectorName = table.Column<string>(nullable: true),
                    InspectorSurname = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.InspectorId);
                });

            migrationBuilder.CreateTable(
                name: "Interprises",
                columns: table => new
                {
                    InterpriseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameInterprise = table.Column<string>(nullable: true),
                    FormOfOwership = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    BossInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interprises", x => x.InterpriseId);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ViolationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameViolation = table.Column<string>(nullable: true),
                    Fine = table.Column<float>(nullable: false),
                    CorrectionPeriod = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ViolationId);
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    CheckID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InspectorId = table.Column<int>(nullable: false),
                    InterpriseId = table.Column<int>(nullable: false),
                    ViolationId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ProtocolNumber = table.Column<int>(nullable: false),
                    Responsible = table.Column<string>(nullable: true),
                    Fine = table.Column<float>(nullable: false),
                    CorrectionPeriod = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.CheckID);
                    table.ForeignKey(
                        name: "FK_Checks_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "InspectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checks_Interprises_InterpriseId",
                        column: x => x.InterpriseId,
                        principalTable: "Interprises",
                        principalColumn: "InterpriseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checks_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "ViolationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checks_InspectorId",
                table: "Checks",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_InterpriseId",
                table: "Checks",
                column: "InterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_ViolationId",
                table: "Checks",
                column: "ViolationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "Interprises");

            migrationBuilder.DropTable(
                name: "Violations");
        }
    }
}
