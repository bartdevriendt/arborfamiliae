using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArborFamiliae.Data.Mysql.Migrations
{
    public partial class FixPersonEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Persons_PersonId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PersonId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Events",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PersonId",
                table: "Events",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Persons_PersonId",
                table: "Events",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
