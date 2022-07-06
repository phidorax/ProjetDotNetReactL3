using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class _20220707131458_developpement_models_v213 : Migration
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
                name: "UtilisateursLocal",
                columns: table => new
                {
                    ID_Local = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateursLocal", x => x.ID_Local);
                });

            migrationBuilder.CreateTable(
                name: "UtilisateursMicrosoft",
                columns: table => new
                {
                    ID_Microsoft = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateursMicrosoft", x => x.ID_Microsoft);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    ID_Utilisateur = table.Column<Guid>(type: "uuid", nullable: false),
                    Pseudo = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ID_Utilisateur_LocalID_Local = table.Column<Guid>(type: "uuid", nullable: false),
                    ID_Utilisateur_MicrosoftID_Microsoft = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.ID_Utilisateur);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                        column: x => x.ID_Utilisateur_LocalID_Local,
                        principalTable: "UtilisateursLocal",
                        principalColumn: "ID_Local",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                        column: x => x.ID_Utilisateur_MicrosoftID_Microsoft,
                        principalTable: "UtilisateursMicrosoft",
                        principalColumn: "ID_Microsoft",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mondes",
                columns: table => new
                {
                    ID_Monde = table.Column<Guid>(type: "uuid", nullable: false),
                    NomMonde = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type_Monde = table.Column<string>(type: "text", nullable: false),
                    Date_Creation_Monde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fin_Monde = table.Column<bool>(type: "boolean", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: true),
                    UtilisateurID_Utilisateur = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "Mer",
                columns: table => new
                {
                    ID_Mer = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Mer = table.Column<string>(type: "text", nullable: false),
                    Limite_ile = table.Column<float>(type: "real", nullable: false),
                    Score_Mer = table.Column<int>(type: "integer", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: true),
                    MondeID_Monde = table.Column<Guid>(type: "uuid", nullable: true)
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
                    ID_Parametrage = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Parametrage = table.Column<string>(type: "text", nullable: false),
                    Lancement_Evolution_Parametrage = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temps_Evolution_Parametrage = table.Column<float>(type: "real", nullable: false),
                    Vitesse_Evolution_Parametrage = table.Column<int>(type: "integer", nullable: false),
                    MondeID_Monde = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "Iles",
                columns: table => new
                {
                    ID_Ile = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Ile = table.Column<string>(type: "text", nullable: false),
                    Score_Ile = table.Column<int>(type: "integer", nullable: false),
                    Classement_global = table.Column<float>(type: "real", nullable: true),
                    MerID_Mer = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iles", x => x.ID_Ile);
                    table.ForeignKey(
                        name: "FK_Iles_Classement_Classement_global",
                        column: x => x.Classement_global,
                        principalTable: "Classement",
                        principalColumn: "Classement_global");
                    table.ForeignKey(
                        name: "FK_Iles_Mer_MerID_Mer",
                        column: x => x.MerID_Mer,
                        principalTable: "Mer",
                        principalColumn: "ID_Mer");
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    ID_Village = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Village = table.Column<string>(type: "text", nullable: false),
                    Score_Village = table.Column<int>(type: "integer", nullable: false),
                    IleID_Ile = table.Column<Guid>(type: "uuid", nullable: true),
                    UtilisateurID_Utilisateur = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.ID_Village);
                    table.ForeignKey(
                        name: "FK_Villages_Iles_IleID_Ile",
                        column: x => x.IleID_Ile,
                        principalTable: "Iles",
                        principalColumn: "ID_Ile");
                    table.ForeignKey(
                        name: "FK_Villages_Utilisateurs_UtilisateurID_Utilisateur",
                        column: x => x.UtilisateurID_Utilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID_Utilisateur");
                });

            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    ID_Batiment = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Batiment = table.Column<string>(type: "text", nullable: false),
                    Niveau_Batiment = table.Column<int>(type: "integer", nullable: false),
                    Score_Total_Batiment = table.Column<int>(type: "integer", nullable: false),
                    VillageID_Village = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.ID_Batiment);
                    table.ForeignKey(
                        name: "FK_Batiments_Villages_VillageID_Village",
                        column: x => x.VillageID_Village,
                        principalTable: "Villages",
                        principalColumn: "ID_Village");
                });

            migrationBuilder.CreateTable(
                name: "BatimentsParametrages",
                columns: table => new
                {
                    ID_Batiment_Parametrage = table.Column<Guid>(type: "uuid", nullable: false),
                    Nom_Batiment_Parametrage = table.Column<string>(type: "text", nullable: false),
                    Score_Progression_Batiment_Parametrage = table.Column<int>(type: "integer", nullable: false),
                    BatimentID_Batiment = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "CoutRessources",
                columns: table => new
                {
                    ID_Cout_Ressource = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cout_Ressource = table.Column<int>(type: "integer", nullable: false),
                    ID_Ressource = table.Column<Guid>(type: "uuid", nullable: false),
                    BatimentParametrageID_Batiment_Parametrage = table.Column<Guid>(type: "uuid", nullable: true),
                    VillageID_Village = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "IX_Batiments_VillageID_Village",
                table: "Batiments",
                column: "VillageID_Village");

            migrationBuilder.CreateIndex(
                name: "IX_BatimentsParametrages_BatimentID_Batiment",
                table: "BatimentsParametrages",
                column: "BatimentID_Batiment");

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
                name: "IX_Table_Parametrages_MondeID_Monde",
                table: "Table_Parametrages",
                column: "MondeID_Monde");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                column: "ID_Utilisateur_LocalID_Local");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs",
                column: "ID_Utilisateur_MicrosoftID_Microsoft");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_IleID_Ile",
                table: "Villages",
                column: "IleID_Ile");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_UtilisateurID_Utilisateur",
                table: "Villages",
                column: "UtilisateurID_Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoutRessources");

            migrationBuilder.DropTable(
                name: "Table_Parametrages");

            migrationBuilder.DropTable(
                name: "BatimentsParametrages");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Batiments");

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

            migrationBuilder.DropTable(
                name: "UtilisateursLocal");

            migrationBuilder.DropTable(
                name: "UtilisateursMicrosoft");
        }
    }
}
