using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArborFamiliae.Data.Mysql.Migrations
{
    public partial class UpdatePersonNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Name_Persons_PersonId",
                table: "Name");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Name_PrimaryNameId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PrimaryNameId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PrimaryNameId",
                table: "Persons");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Name",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Name",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Name_Persons_PersonId",
                table: "Name",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Name_Persons_PersonId",
                table: "Name");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "PrimaryNameId",
                table: "Persons",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Name",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PrimaryNameId",
                table: "Persons",
                column: "PrimaryNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Name_Persons_PersonId",
                table: "Name",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Name_PrimaryNameId",
                table: "Persons",
                column: "PrimaryNameId",
                principalTable: "Name",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
