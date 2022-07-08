using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v2110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Max_Stock",
                table: "StockageRessources",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max_Stock",
                table: "StockageRessources");
        }
    }
}
