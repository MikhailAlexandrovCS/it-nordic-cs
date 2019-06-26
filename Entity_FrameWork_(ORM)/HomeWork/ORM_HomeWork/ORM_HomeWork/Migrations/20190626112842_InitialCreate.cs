using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORM_HomeWork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FK_Address_CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adress_City_FK_Address_CityId",
                        column: x => x.FK_Address_CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    FK_Contractor_PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractor_Position_FK_Contractor_PositionId",
                        column: x => x.FK_Contractor_PositionId,
                        principalSchema: "dbo",
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SendingStatus",
                schema: "dbo",
                columns: table => new
                {
                    UpdateStatusDateTime = table.Column<DateTimeOffset>(nullable: false),
                    PostalItemId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    SendingContractorId = table.Column<int>(nullable: false),
                    SendingAdressId = table.Column<int>(nullable: false),
                    ReceivingContractorId = table.Column<int>(nullable: false),
                    ReceivingAdressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendingStatus", x => new { x.PostalItemId, x.UpdateStatusDateTime, x.StatusId, x.SendingContractorId, x.SendingAdressId, x.ReceivingContractorId, x.ReceivingAdressId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SendingStatus_PostalItem_PostalItemId",
                        column: x => x.PostalItemId,
                        principalSchema: "dbo",
                        principalTable: "PostalItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_SendingStatus_Adress_ReceivingAdressId",
                        column: x => x.ReceivingAdressId,
                        principalSchema: "dbo",
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SendingStatus_Contractor_ReceivingContractorId",
                        column: x => x.ReceivingContractorId,
                        principalSchema: "dbo",
                        principalTable: "Contractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SendingStatus_Adress_SendingAdressId",
                        column: x => x.SendingAdressId,
                        principalSchema: "dbo",
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SendingStatus_Contractor_SendingContractorId",
                        column: x => x.SendingContractorId,
                        principalSchema: "dbo",
                        principalTable: "Contractor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SendingStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adress_FK_Address_CityId",
                schema: "dbo",
                table: "Adress",
                column: "FK_Address_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_FK_Contractor_PositionId",
                schema: "dbo",
                table: "Contractor",
                column: "FK_Contractor_PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_ReceivingAdressId",
                schema: "dbo",
                table: "SendingStatus",
                column: "ReceivingAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_ReceivingContractorId",
                schema: "dbo",
                table: "SendingStatus",
                column: "ReceivingContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_SendingAdressId",
                schema: "dbo",
                table: "SendingStatus",
                column: "SendingAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_SendingContractorId",
                schema: "dbo",
                table: "SendingStatus",
                column: "SendingContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_StatusId",
                schema: "dbo",
                table: "SendingStatus",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendingStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PostalItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Adress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contractor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "dbo");
        }
    }
}
