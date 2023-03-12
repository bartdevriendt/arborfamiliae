using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArborFamiliae.Data.Mysql.Migrations
{
    public partial class AddPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Places",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "EnclosedById",
                table: "Places",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Places",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Places",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PlaceType",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_EnclosedById",
                table: "Places",
                column: "EnclosedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places",
                column: "EnclosedById",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_EnclosedById",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "EnclosedById",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceType",
                table: "Places");
        }
    }
}
