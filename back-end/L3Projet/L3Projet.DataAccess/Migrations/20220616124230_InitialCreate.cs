using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Mers",
                columns: table => new
                {
                    ID_Mer = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre_d_ile = table.Column<float>(type: "real", nullable: false),
                    MondeID_Monde = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mers", x => x.ID_Mer);
                    table.ForeignKey(
                        name: "FK_Mers_Mondes_MondeID_Monde",
                        column: x => x.MondeID_Monde,
                        principalTable: "Mondes",
                        principalColumn: "ID_Monde");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mers_MondeID_Monde",
                table: "Mers",
                column: "MondeID_Monde");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mondes");
        }
    }
}
