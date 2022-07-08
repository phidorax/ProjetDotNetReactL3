using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v2111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fin_Construction",
                table: "Batiments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fin_Construction",
                table: "Batiments");
        }
    }
}
