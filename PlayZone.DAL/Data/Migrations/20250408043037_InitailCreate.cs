using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlayZone.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitailCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameDevices",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDevices", x => new { x.GameId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_GameDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameDevices_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46e66292-65d9-4b3f-a429-42fe2de55371"), "Sports" },
                    { new Guid("6671ce52-49cf-416f-8ff4-5364f9092115"), "Horror" },
                    { new Guid("6964b615-a3d6-4b60-a317-75c84e5c10b6"), "Action" },
                    { new Guid("91a7cad7-e569-4566-9cea-380dbb8959cb"), "Racing" },
                    { new Guid("b513a8fc-2200-4538-91c3-4986c6b0aba1"), "Simulation" },
                    { new Guid("b9bfb3a1-f5c3-4029-bc0e-230043d41aa1"), "Strategy" },
                    { new Guid("d54f03bb-4c38-4e9d-b5a8-aa419a69d15c"), "Puzzle" },
                    { new Guid("e6a466ff-7f2f-4d6d-ba09-451d295dd130"), "RPG" },
                    { new Guid("f676e0fb-aec3-409b-846b-fa5f0bf5b3c0"), "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("2edcb1b3-f15f-4b75-91dd-226c395e9b14"), "bi bi-nintendo-switch", "Nintendo Switch" },
                    { new Guid("9047443a-dd73-4872-b40c-26d3624af5eb"), "bi bi-pc-display", "PC" },
                    { new Guid("b03b81c5-3c75-494b-9154-1e227a5627e0"), "bi bi-xbox", "Xbox" },
                    { new Guid("c338cb39-0e7c-42d1-bc1b-128e7263988c"), "bi bi-playstation", "PlayStation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDevices_DeviceId",
                table: "GameDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDevices");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
