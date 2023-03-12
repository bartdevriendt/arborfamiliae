using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArborFamiliae.Data.Mysql.Migrations
{
    public partial class UpdatePlaceEnclosedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnclosedById",
                table: "Places",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places",
                column: "EnclosedById",
                principalTable: "Places",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnclosedById",
                table: "Places",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Places_EnclosedById",
                table: "Places",
                column: "EnclosedById",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
