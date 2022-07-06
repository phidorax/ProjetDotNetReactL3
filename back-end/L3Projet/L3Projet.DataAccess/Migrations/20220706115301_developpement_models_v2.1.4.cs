using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class developpement_models_v214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                column: "ID_Utilisateur_LocalID_Local",
                principalTable: "UtilisateursLocal",
                principalColumn: "ID_Local");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                table: "Utilisateurs",
                column: "ID_Utilisateur_MicrosoftID_Microsoft",
                principalTable: "UtilisateursMicrosoft",
                principalColumn: "ID_Microsoft");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursLocal_ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_UtilisateursMicrosoft_ID_Utilisateur_Microsoft~",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Utilisateur_MicrosoftID_Microsoft",
                table: "Utilisateurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Utilisateur_LocalID_Local",
                table: "Utilisateurs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
        }
    }
}
