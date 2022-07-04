using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Batiments",
                columns: table => new
                {
                    ID_Batiment = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Batiment = table.Column<string>(type: "text", nullable: false),
                    Niveau_Batiment = table.Column<int>(type: "integer", nullable: false),
                    Score_Total_Batiment = table.Column<int>(type: "integer", nullable: false),
                    VillageID_Village = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.ID_Batiment);
                });

            migrationBuilder.CreateTable(
                name: "BatimentsParametrages",
                columns: table => new
                {
                    ID_Batiment_Parametrage = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Batiment_Parametrage = table.Column<string>(type: "text", nullable: false),
                    Cout_Bois_Batiment_Parametrage = table.Column<float>(type: "real", nullable: false),
                    Cout_Pierre_Batiment_Parametrage = table.Column<float>(type: "real", nullable: false),
                    Cout_Argent_Batiment_Parametrage = table.Column<float>(type: "real", nullable: false),
                    Score_Progression_Batiment_Parametrage = table.Column<int>(type: "integer", nullable: false),
                    BatimentID_Batiment = table.Column<Guid>(type: "serial", nullable: false),
                    ParametrageID_Parametrage = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatimentsParametrages", x => x.ID_Batiment_Parametrage);
                    table.ForeignKey(
                        name: "FK_BatimentsParametrages_Batiments_BatimentID_Batiment",
                        column: x => x.BatimentID_Batiment,
                        principalTable: "Batiments",
                        principalColumn: "ID_Batiment");
                });

            migrationBuilder.CreateTable(
                name: "Iles",
                columns: table => new
                {
                    ID_Ile = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Ile = table.Column<string>(type: "text", nullable: false),
                    Score_Ile = table.Column<int>(type: "integer", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: false),
                    MerID_Mer = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iles", x => x.ID_Ile);
                    table.ForeignKey(
                        name: "FK_Iles_Classement_Classement_global",
                        column: x => x.Classement_global,
                        principalTable: "Classement",
                        principalColumn: "Classement_global");
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    ID_Village = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Village = table.Column<string>(type: "text", nullable: false),
                    Joueur_Village = table.Column<bool>(type: "boolean", nullable: false),
                    Score_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource1_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource2_Village = table.Column<int>(type: "integer", nullable: false),
                    Cout_Ressource3_Village = table.Column<int>(type: "integer", nullable: false),
                    IleID_Ile = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.ID_Village);
                    table.ForeignKey(
                        name: "FK_Villages_Iles_IleID_Ile",
                        column: x => x.IleID_Ile,
                        principalTable: "Iles",
                        principalColumn: "ID_Ile");
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    ID_Utilisateur = table.Column<Guid>(type: "serial", nullable: false),
                    Pseudo = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    VillageID_Village = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.ID_Utilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Villages_VillageID_Village",
                        column: x => x.VillageID_Village,
                        principalTable: "Villages",
                        principalColumn: "ID_Village");
                });

            migrationBuilder.CreateTable(
                name: "Mondes",
                columns: table => new
                {
                    ID_Monde = table.Column<Guid>(type: "serial", nullable: false),
                    NomMonde = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type_Monde = table.Column<string>(type: "text", nullable: false),
                    Date_Creation_Monde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fin_Monde = table.Column<bool>(type: "boolean", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: false),
                    UtilisateurID_Utilisateur = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mondes", x => x.ID_Monde);
                    table.ForeignKey(
                        name: "FK_Mondes_Classement_Classement_global",
                        column: x => x.Classement_global,
                        principalTable: "Classement",
                        principalColumn: "Classement_global");
                    table.ForeignKey(
                        name: "FK_Mondes_Utilisateurs_UtilisateurID_Utilisateur",
                        column: x => x.UtilisateurID_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID_Utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "UtilisateursLocal",
                columns: table => new
                {
                    ID_Local = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UtilisateurID_Utilisateur = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateursLocal", x => x.ID_Local);
                    table.ForeignKey(
                        name: "FK_UtilisateursLocal_Utilisateurs_UtilisateurID_Utilisateur",
                        column: x => x.UtilisateurID_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID_Utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "UtilisateursMicrosoft",
                columns: table => new
                {
                    ID_Microsoft = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    UtilisateurID_Utilisateur = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateursMicrosoft", x => x.ID_Microsoft);
                    table.ForeignKey(
                        name: "FK_UtilisateursMicrosoft_Utilisateurs_UtilisateurID_Utilisateur",
                        column: x => x.UtilisateurID_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID_Utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Mer",
                columns: table => new
                {
                    ID_Mer = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Mer = table.Column<string>(type: "text", nullable: false),
                    Nombre_d_ile = table.Column<float>(type: "real", nullable: false),
                    Score_Mer = table.Column<int>(type: "integer", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: false),
                    MondeID_Monde = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mer", x => x.ID_Mer);
                    table.ForeignKey(
                        name: "FK_Mer_Classement_Classement_global",
                        column: x => x.Classement_global,
                        principalTable: "Classement",
                        principalColumn: "Classement_global");
                    table.ForeignKey(
                        name: "FK_Mer_Mondes_MondeID_Monde",
                        column: x => x.MondeID_Monde,
                        principalTable: "Mondes",
                        principalColumn: "ID_Monde");
                });

            migrationBuilder.CreateTable(
                name: "Table_Parametrages",
                columns: table => new
                {
                    ID_Parametrage = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Parametrage = table.Column<string>(type: "text", nullable: false),
                    Lancement_Evolution_Parametrage = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temps_Evolution_Parametrage = table.Column<float>(type: "real", nullable: false),
                    Vitesse_Evolution_Parametrage = table.Column<int>(type: "integer", nullable: false),
                    MondeID_Monde = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Parametrages", x => x.ID_Parametrage);
                    table.ForeignKey(
                        name: "FK_Table_Parametrages_Mondes_MondeID_Monde",
                        column: x => x.MondeID_Monde,
                        principalTable: "Mondes",
                        principalColumn: "ID_Monde");
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    ID_Ressource = table.Column<Guid>(type: "serial", nullable: false),
                    Nom_Ressource = table.Column<string>(type: "text", nullable: false),
                    Production_Naturelle_Ressource = table.Column<int>(type: "integer", nullable: false),
                    BatimentParametrageID_Batiment_Parametrage = table.Column<Guid>(type: "serial", nullable: false),
                    ParametrageID_Parametrage = table.Column<Guid>(type: "serial", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.ID_Ressource);
                    table.ForeignKey(
                        name: "FK_Ressources_BatimentsParametrages_BatimentParametrageID_Bati~",
                        column: x => x.BatimentParametrageID_Batiment_Parametrage,
                        principalTable: "BatimentsParametrages",
                        principalColumn: "ID_Batiment_Parametrage");
                    table.ForeignKey(
                        name: "FK_Ressources_Table_Parametrages_ParametrageID_Parametrage",
                        column: x => x.ParametrageID_Parametrage,
                        principalTable: "Table_Parametrages",
                        principalColumn: "ID_Parametrage");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batiments_VillageID_Village",
                table: "Batiments",
                column: "VillageID_Village");

            migrationBuilder.CreateIndex(
                name: "IX_BatimentsParametrages_BatimentID_Batiment",
                table: "BatimentsParametrages",
                column: "BatimentID_Batiment");

            migrationBuilder.CreateIndex(
                name: "IX_BatimentsParametrages_ParametrageID_Parametrage",
                table: "BatimentsParametrages",
                column: "ParametrageID_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_Iles_Classement_global",
                table: "Iles",
                column: "Classement_global");

            migrationBuilder.CreateIndex(
                name: "IX_Iles_MerID_Mer",
                table: "Iles",
                column: "MerID_Mer");

            migrationBuilder.CreateIndex(
                name: "IX_Mer_Classement_global",
                table: "Mer",
                column: "Classement_global");

            migrationBuilder.CreateIndex(
                name: "IX_Mer_MondeID_Monde",
                table: "Mer",
                column: "MondeID_Monde");

            migrationBuilder.CreateIndex(
                name: "IX_Mondes_Classement_global",
                table: "Mondes",
                column: "Classement_global");

            migrationBuilder.CreateIndex(
                name: "IX_Mondes_UtilisateurID_Utilisateur",
                table: "Mondes",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_BatimentParametrageID_Batiment_Parametrage",
                table: "Ressources",
                column: "BatimentParametrageID_Batiment_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_ParametrageID_Parametrage",
                table: "Ressources",
                column: "ParametrageID_Parametrage");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Parametrages_MondeID_Monde",
                table: "Table_Parametrages",
                column: "MondeID_Monde");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_VillageID_Village",
                table: "Utilisateurs",
                column: "VillageID_Village");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursLocal_UtilisateurID_Utilisateur",
                table: "UtilisateursLocal",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateursMicrosoft_UtilisateurID_Utilisateur",
                table: "UtilisateursMicrosoft",
                column: "UtilisateurID_Utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_IleID_Ile",
                table: "Villages",
                column: "IleID_Ile");

            migrationBuilder.AddForeignKey(
                name: "FK_Batiments_Villages_VillageID_Village",
                table: "Batiments",
                column: "VillageID_Village",
                principalTable: "Villages",
                principalColumn: "ID_Village");

            migrationBuilder.AddForeignKey(
                name: "FK_BatimentsParametrages_Table_Parametrages_ParametrageID_Para~",
                table: "BatimentsParametrages",
                column: "ParametrageID_Parametrage",
                principalTable: "Table_Parametrages",
                principalColumn: "ID_Parametrage");

            migrationBuilder.AddForeignKey(
                name: "FK_Iles_Mer_MerID_Mer",
                table: "Iles",
                column: "MerID_Mer",
                principalTable: "Mer",
                principalColumn: "ID_Mer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Villages_VillageID_Village",
                table: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UtilisateursLocal");

            migrationBuilder.DropTable(
                name: "UtilisateursMicrosoft");

            migrationBuilder.DropTable(
                name: "BatimentsParametrages");

            migrationBuilder.DropTable(
                name: "Batiments");

            migrationBuilder.DropTable(
                name: "Table_Parametrages");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Iles");

            migrationBuilder.DropTable(
                name: "Mer");

            migrationBuilder.DropTable(
                name: "Mondes");

            migrationBuilder.DropTable(
                name: "Classement");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
