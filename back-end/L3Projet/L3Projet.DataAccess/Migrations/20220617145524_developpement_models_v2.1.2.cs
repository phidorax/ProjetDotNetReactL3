using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatimentsParametrages_Table_Parametrages_ParametrageID_Para~",
                table: "BatimentsParametrages");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_BatimentsParametrages_BatimentParametrageID_Bati~",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Ressources_Table_Parametrages_ParametrageID_Parametrage",
                table: "Ressources");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Villages_VillageID_Village",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursLocal_Utilisateurs_UtilisateurID_Utilisateur",
                table: "UtilisateursLocal");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateursMicrosoft_Utilisateurs_UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft");

            migrationBuilder.DropIndex(
                name: "IX_UtilisateursMicrosoft_UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft");

            migrationBuilder.DropIndex(
                name: "IX_UtilisateursLocal_UtilisateurID_Utilisateur",
                table: "UtilisateursLocal");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_VillageID_Village",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_BatimentParametrageID_Batiment_Parametrage",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_Ressources_ParametrageID_Parametrage",
                table: "Ressources");

            migrationBuilder.DropIndex(
                name: "IX_BatimentsParametrages_ParametrageID_Parametrage",
                table: "BatimentsParametrages");

            migrationBuilder.DropColumn(
                name: "Cout_Ressource1_Village",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "Cout_Ressource2_Village",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "Cout_Ressource3_Village",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "Joueur_Village",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft");

            migrationBuilder.DropColumn(
                name: "UtilisateurID_Utilisateur",
                table: "UtilisateursLocal");

            migrationBuilder.DropColumn(
                name: "VillageID_Village",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "BatimentParametrageID_Batiment_Parametrage",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "ParametrageID_Parametrage",
                table: "Ressources");

            migrationBuilder.DropColumn(
                name: "Cout_Argent_Batiment_Parametrage",
                table: "BatimentsParametrages");

            migrationBuilder.DropColumn(
                name: "Cout_Bois_Batiment_Parametrage",
                table: "BatimentsParametrages");

            migrationBuilder.DropColumn(
                name: "Cout_Pierre_Batiment_Parametrage",
                table: "BatimentsParametrages");

            migrationBuilder.DropColumn(
                name: "ParametrageID_Parametrage",
                table: "BatimentsParametrages");

            migrationBuilder.RenameColumn(
                name: "Nombre_d_ile",
                table: "Mer",
                newName: "Limite_ile");

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurID_Utilisateur",
                table: "Villages",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CoutRessources",
                columns: table => new
                {
                    ID_Cout_Ressource = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cout_Ressource = table.Column<int>(type: "integer", nullable: false),
                    ID_Ressource = table.Column<Guid>(type: "serial", nullable: false),
                    BatimentParametrageID_Batiment_Parametrage = table.Column<Guid>(type: "serial", nullable: false),
                    VillageID_Village = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoutRessources", x => x.ID_Cout_Ressource);
                    table.ForeignKey(
                        name: "FK_CoutRessources_BatimentsParametrages_BatimentParametrageID_~",
                        column: x => x.BatimentParametrageID_Batiment_Parametrage,
                        principalTable: "BatimentsParametrages",
                        principalColumn: "ID_Batiment_Parametrage");
                    table.ForeignKey(
                        name: "FK_CoutRessources_Ressources_ID_Ressource",
                        column: x => x.ID_Ressource,
                        principalTable: "Ressources",
                        principalColumn: "ID_Ressource",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoutRessources_Villages_VillageID_Village",
                        column: x => x.VillageID_Village,
                        principalTable: "Villages",
                        principalColumn: "ID_Village");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Villages_UtilisateurID_Utilisateur",
                table: "Villages",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                column: "ID_Utilisateur_LocalID_Local");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs",
                column: "ID_Utilisateur_MicrosoftID_Microsoft");

            migrationBuilder.CreateIndex(
                name: "IX_CoutRessources_BatimentParametrageID_Batiment_Parametrage",
                table: "CoutRessources",
                column: "BatimentParametrageID_Batiment_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_CoutRessources_ID_Ressource",
                table: "CoutRessources",
                column: "ID_Ressource");

            migrationBuilder.CreateIndex(
                name: "IX_CoutRessources_VillageID_Village",
                table: "CoutRessources",
                column: "VillageID_Village");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                column: "ID_Utilisateur_LocalID_Local",
                principalTable: "UtilisateursLocal",
                principalColumn: "ID_Local",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                table: "Utilisateurs",
                column: "ID_Utilisateur_MicrosoftID_Microsoft",
                principalTable: "UtilisateursMicrosoft",
                principalColumn: "ID_Microsoft",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Utilisateurs_UtilisateurID_Utilisateur",
                table: "Villages",
                column: "UtilisateurID_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "ID_Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Utilisateurs_UtilisateurID_Utilisateur",
                table: "Villages");

            migrationBuilder.DropTable(
                name: "CoutRessources");

            migrationBuilder.DropIndex(
                name: "IX_Villages_UtilisateurID_Utilisateur",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UtilisateurID_Utilisateur",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs");

            migrationBuilder.RenameColumn(
                name: "Limite_ile",
                table: "Mer",
                newName: "Nombre_d_ile");

            migrationBuilder.AddColumn<int>(
                name: "Cout_Ressource1_Village",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cout_Ressource2_Village",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cout_Ressource3_Village",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Joueur_Village",
                table: "Villages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UtilisateurID_Utilisateur",
                table: "UtilisateursLocal",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "VillageID_Village",
                table: "Utilisateurs",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "BatimentParametrageID_Batiment_Parametrage",
                table: "Ressources",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParametrageID_Parametrage",
                table: "Ressources",
                type: "serial",
                nullable: false);

            migrationBuilder.AddColumn<float>(
                name: "Cout_Argent_Batiment_Parametrage",
                table: "BatimentsParametrages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cout_Bois_Batiment_Parametrage",
                table: "BatimentsParametrages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cout_Pierre_Batiment_Parametrage",
                table: "BatimentsParametrages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "ParametrageID_Parametrage",
                table: "BatimentsParametrages",
                type: "serial",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursMicrosoft_UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursLocal_UtilisateurID_Utilisateur",
                table: "UtilisateursLocal",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_VillageID_Village",
                table: "Utilisateurs",
                column: "VillageID_Village");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_BatimentParametrageID_Batiment_Parametrage",
                table: "Ressources",
                column: "BatimentParametrageID_Batiment_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_ParametrageID_Parametrage",
                table: "Ressources",
                column: "ParametrageID_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_BatimentsParametrages_ParametrageID_Parametrage",
                table: "BatimentsParametrages",
                column: "ParametrageID_Parametrage");

            migrationBuilder.AddForeignKey(
                name: "FK_BatimentsParametrages_Table_Parametrages_ParametrageID_Para~",
                table: "BatimentsParametrages",
                column: "ParametrageID_Parametrage",
                principalTable: "Table_Parametrages",
                principalColumn: "ID_Parametrage");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_BatimentsParametrages_BatimentParametrageID_Bati~",
                table: "Ressources",
                column: "BatimentParametrageID_Batiment_Parametrage",
                principalTable: "BatimentsParametrages",
                principalColumn: "ID_Batiment_Parametrage");

            migrationBuilder.AddForeignKey(
                name: "FK_Ressources_Table_Parametrages_ParametrageID_Parametrage",
                table: "Ressources",
                column: "ParametrageID_Parametrage",
                principalTable: "Table_Parametrages",
                principalColumn: "ID_Parametrage");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Villages_VillageID_Village",
                table: "Utilisateurs",
                column: "VillageID_Village",
                principalTable: "Villages",
                principalColumn: "ID_Village");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursLocal_Utilisateurs_UtilisateurID_Utilisateur",
                table: "UtilisateursLocal",
                column: "UtilisateurID_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "ID_Utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateursMicrosoft_Utilisateurs_UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft",
                column: "UtilisateurID_Utilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "ID_Utilisateur");
        }
    }
}
