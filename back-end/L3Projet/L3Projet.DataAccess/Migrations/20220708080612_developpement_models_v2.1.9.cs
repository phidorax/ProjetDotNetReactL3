using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v219 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Resource_Stock",
                table: "StockageRessources",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "BatimentID_Batiment",
                table: "StockageRessources",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockageRessources_BatimentID_Batiment",
                table: "StockageRessources",
                column: "BatimentID_Batiment");

            migrationBuilder.AddForeignKey(
                name: "FK_StockageRessources_Batiments_BatimentID_Batiment",
                table: "StockageRessources",
                column: "BatimentID_Batiment",
                principalTable: "Batiments",
                principalColumn: "ID_Batiment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockageRessources_Batiments_BatimentID_Batiment",
                table: "StockageRessources");

            migrationBuilder.DropIndex(
                name: "IX_StockageRessources_BatimentID_Batiment",
                table: "StockageRessources");

            migrationBuilder.DropColumn(
                name: "BatimentID_Batiment",
                table: "StockageRessources");

            migrationBuilder.AlterColumn<int>(
                name: "Resource_Stock",
                table: "StockageRessources",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");
        }
    }
}
