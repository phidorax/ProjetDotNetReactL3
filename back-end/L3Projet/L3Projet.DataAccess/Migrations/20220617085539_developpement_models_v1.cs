using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    ID_Batiment = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Batiment = table.Column<string>(type: "text", nullable: false),
                    Cout_Batiment = table.Column<float>(type: "real", nullable: false),
                    Niveau_Batiment = table.Column<int>(type: "integer", nullable: false),
                    Score_Batiment = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.ID_Batiment);
                });

            migrationBuilder.CreateTable(
                name: "Classement",
                columns: table => new
                {
                    Classement_global = table.Column<float>(type: "real", nullable: false),
                    Classement_mer = table.Column<float>(type: "real", nullable: false),
                    Classement_ile = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classement", x => x.Classement_global);
                });

            migrationBuilder.CreateTable(
                name: "Iles",
                columns: table => new
                {
                    ID_Ile = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Ile = table.Column<string>(type: "text", nullable: false),
                    Score_Ile = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iles", x => x.ID_Ile);
                });

            migrationBuilder.CreateTable(
                name: "Mer",
                columns: table => new
                {
                    ID_Mer = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Mer = table.Column<string>(type: "text", nullable: false),
                    Nombre_d_ile = table.Column<float>(type: "real", nullable: false),
                    Score_Mer = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mer", x => x.ID_Mer);
                });

            migrationBuilder.CreateTable(
                name: "Mondes",
                columns: table => new
                {
                    ID_Monde = table.Column<Guid>(type: "uuid", nullable: false),
                    NomMonde = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type_Monde = table.Column<string>(type: "text", nullable: false),
                    Date_Creation_Monde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fin_Monde = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mondes", x => x.ID_Monde);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    ID_Ressource = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Ressource = table.Column<string>(type: "text", nullable: false),
                    Production_Naturelle_Ressource = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.ID_Ressource);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    ID_Village = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Village = table.Column<string>(type: "text", nullable: false),
                    Score_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource1_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource2_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource3_Village = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.ID_Village);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batiments");

            migrationBuilder.DropTable(
                name: "Classement");

            migrationBuilder.DropTable(
                name: "Iles");

            migrationBuilder.DropTable(
                name: "Mer");

            migrationBuilder.DropTable(
                name: "Mondes");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Villages");
        }
    }
}
