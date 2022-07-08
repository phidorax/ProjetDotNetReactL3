﻿// <auto-generated />
using System;
using L3Projet.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace L3Projet.DataAccess.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("L3Projet.Common.Models.Batiment", b =>
                {
                    b.Property<Guid>("ID_Batiment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Fin_Construction")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Niveau_Batiment")
                        .HasColumnType("integer");

                    b.Property<int>("Nom_Batiment")
                        .HasColumnType("integer");

                    b.Property<int>("Score_Total_Batiment")
                        .HasColumnType("integer");

                    b.Property<Guid?>("VillageID_Village")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Batiment");

                    b.HasIndex("VillageID_Village");

                    b.ToTable("Batiments");
                });

            modelBuilder.Entity("L3Projet.Common.Models.BatimentParametrage", b =>
                {
                    b.Property<Guid>("ID_Batiment_Parametrage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BatimentID_Batiment")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom_Batiment_Parametrage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score_Progression_Batiment_Parametrage")
                        .HasColumnType("integer");

                    b.HasKey("ID_Batiment_Parametrage");

                    b.HasIndex("BatimentID_Batiment");

                    b.ToTable("BatimentsParametrages");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Classement", b =>
                {
                    b.Property<float>("Classement_global")
                        .HasColumnType("real");

                    b.Property<float>("Classement_ile")
                        .HasColumnType("real");

                    b.Property<float>("Classement_mer")
                        .HasColumnType("real");

                    b.HasKey("Classement_global");

                    b.ToTable("Classement");
                });

            modelBuilder.Entity("L3Projet.Common.Models.CoutRessources", b =>
                {
                    b.Property<int>("ID_Cout_Ressource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Cout_Ressource"));

                    b.Property<Guid?>("BatimentID_Batiment")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BatimentParametrageID_Batiment_Parametrage")
                        .HasColumnType("uuid");

                    b.Property<int>("Cout_Ressource")
                        .HasColumnType("integer");

                    b.Property<Guid>("ID_Ressource")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VillageID_Village")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Cout_Ressource");

                    b.HasIndex("BatimentID_Batiment");

                    b.HasIndex("BatimentParametrageID_Batiment_Parametrage");

                    b.HasIndex("ID_Ressource");

                    b.HasIndex("VillageID_Village");

                    b.ToTable("CoutRessources");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Ile", b =>
                {
                    b.Property<Guid>("ID_Ile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float?>("Classement_global")
                        .HasColumnType("real");

                    b.Property<Guid?>("MerID_Mer")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom_Ile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score_Ile")
                        .HasColumnType("integer");

                    b.HasKey("ID_Ile");

                    b.HasIndex("Classement_global");

                    b.HasIndex("MerID_Mer");

                    b.ToTable("Iles");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Mer", b =>
                {
                    b.Property<Guid>("ID_Mer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float?>("Classement_global")
                        .HasColumnType("real");

                    b.Property<float>("Limite_Ile")
                        .HasColumnType("real");

                    b.Property<Guid?>("MondeID_Monde")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom_Mer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score_Mer")
                        .HasColumnType("integer");

                    b.HasKey("ID_Mer");

                    b.HasIndex("Classement_global");

                    b.HasIndex("MondeID_Monde");

                    b.ToTable("Mer");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Monde", b =>
                {
                    b.Property<Guid>("ID_Monde")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float?>("Classement_global")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date_Creation_Monde")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Fin_Monde")
                        .HasColumnType("boolean");

                    b.Property<string>("Nom_Monde")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NomMonde");

                    b.Property<int>("Type_Monde")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UtilisateurID_Utilisateur")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Monde");

                    b.HasIndex("Classement_global");

                    b.HasIndex("UtilisateurID_Utilisateur");

                    b.ToTable("Mondes");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Parametrage", b =>
                {
                    b.Property<Guid>("ID_Parametrage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Lancement_Evolution_Parametrage")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("MondeID_Monde")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom_Parametrage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Temps_Evolution_Parametrage")
                        .HasColumnType("real");

                    b.Property<int>("Vitesse_Evolution_Parametrage")
                        .HasColumnType("integer");

                    b.HasKey("ID_Parametrage");

                    b.HasIndex("MondeID_Monde");

                    b.ToTable("Table_Parametrages");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Ressources", b =>
                {
                    b.Property<Guid>("ID_Ressource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Nom_Ressource")
                        .HasColumnType("integer");

                    b.Property<int>("Production_Naturelle_Ressource")
                        .HasColumnType("integer");

                    b.HasKey("ID_Ressource");

                    b.ToTable("Ressources");
                });

            modelBuilder.Entity("L3Projet.Common.Models.StockageRessources", b =>
                {
                    b.Property<Guid>("ID_Stockage_Ressource")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BatimentID_Batiment")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Max_Stock")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("Resource_Stock")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid>("RessourceID_Ressource")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Stockage_Ressource");

                    b.HasIndex("BatimentID_Batiment");

                    b.HasIndex("RessourceID_Ressource");

                    b.ToTable("StockageRessources");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Utilisateur", b =>
                {
                    b.Property<Guid>("ID_Utilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ID_Utilisateur_LocalID_Local")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ID_Utilisateur_MicrosoftID_Microsoft")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prénom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Utilisateur");

                    b.HasIndex("ID_Utilisateur_LocalID_Local");

                    b.HasIndex("ID_Utilisateur_MicrosoftID_Microsoft");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("L3Projet.Common.Models.UtilisateurLocal", b =>
                {
                    b.Property<Guid>("ID_Local")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Local");

                    b.ToTable("UtilisateursLocal");
                });

            modelBuilder.Entity("L3Projet.Common.Models.UtilisateurMicrosoft", b =>
                {
                    b.Property<Guid>("ID_Microsoft")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID_Microsoft");

                    b.ToTable("UtilisateursMicrosoft");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Village", b =>
                {
                    b.Property<Guid>("ID_Village")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IleID_Ile")
                        .HasColumnType("uuid");

                    b.Property<string>("Nom_Village")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score_Village")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UtilisateurID_Utilisateur")
                        .HasColumnType("uuid");

                    b.HasKey("ID_Village");

                    b.HasIndex("IleID_Ile");

                    b.HasIndex("UtilisateurID_Utilisateur");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Batiment", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Village", null)
                        .WithMany("Liste_Batiment")
                        .HasForeignKey("VillageID_Village");
                });

            modelBuilder.Entity("L3Projet.Common.Models.BatimentParametrage", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Batiment", null)
                        .WithMany("ID_Batiment_Parametrage")
                        .HasForeignKey("BatimentID_Batiment");
                });

            modelBuilder.Entity("L3Projet.Common.Models.CoutRessources", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Batiment", null)
                        .WithMany("Liste_Cout_Ressources")
                        .HasForeignKey("BatimentID_Batiment");

                    b.HasOne("L3Projet.Common.Models.BatimentParametrage", null)
                        .WithMany("List_Cout_Ressources")
                        .HasForeignKey("BatimentParametrageID_Batiment_Parametrage");

                    b.HasOne("L3Projet.Common.Models.Ressources", "id_ressource")
                        .WithMany()
                        .HasForeignKey("ID_Ressource")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("L3Projet.Common.Models.Village", null)
                        .WithMany("Liste_Cout_Ressources")
                        .HasForeignKey("VillageID_Village");

                    b.Navigation("id_ressource");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Ile", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Classement", null)
                        .WithMany("ID_Ile")
                        .HasForeignKey("Classement_global");

                    b.HasOne("L3Projet.Common.Models.Mer", null)
                        .WithMany("Liste_Iles")
                        .HasForeignKey("MerID_Mer");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Mer", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Classement", null)
                        .WithMany("ID_Mer")
                        .HasForeignKey("Classement_global");

                    b.HasOne("L3Projet.Common.Models.Monde", null)
                        .WithMany("Liste_Mers")
                        .HasForeignKey("MondeID_Monde");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Monde", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Classement", null)
                        .WithMany("ID_Monde")
                        .HasForeignKey("Classement_global");

                    b.HasOne("L3Projet.Common.Models.Utilisateur", null)
                        .WithMany("ID_Monde")
                        .HasForeignKey("UtilisateurID_Utilisateur");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Parametrage", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Monde", null)
                        .WithMany("Monde_Parametrage")
                        .HasForeignKey("MondeID_Monde");
                });

            modelBuilder.Entity("L3Projet.Common.Models.StockageRessources", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Batiment", null)
                        .WithMany("Liste_Stockage_Ressources")
                        .HasForeignKey("BatimentID_Batiment");

                    b.HasOne("L3Projet.Common.Models.Ressources", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceID_Ressource")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Utilisateur", b =>
                {
                    b.HasOne("L3Projet.Common.Models.UtilisateurLocal", "ID_Utilisateur_Local")
                        .WithMany()
                        .HasForeignKey("ID_Utilisateur_LocalID_Local");

                    b.HasOne("L3Projet.Common.Models.UtilisateurMicrosoft", "ID_Utilisateur_Microsoft")
                        .WithMany()
                        .HasForeignKey("ID_Utilisateur_MicrosoftID_Microsoft");

                    b.Navigation("ID_Utilisateur_Local");

                    b.Navigation("ID_Utilisateur_Microsoft");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Village", b =>
                {
                    b.HasOne("L3Projet.Common.Models.Ile", null)
                        .WithMany("ID_Village")
                        .HasForeignKey("IleID_Ile");

                    b.HasOne("L3Projet.Common.Models.Utilisateur", null)
                        .WithMany("ID_Liste_Villages")
                        .HasForeignKey("UtilisateurID_Utilisateur");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Batiment", b =>
                {
                    b.Navigation("ID_Batiment_Parametrage");

                    b.Navigation("Liste_Cout_Ressources");

                    b.Navigation("Liste_Stockage_Ressources");
                });

            modelBuilder.Entity("L3Projet.Common.Models.BatimentParametrage", b =>
                {
                    b.Navigation("List_Cout_Ressources");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Classement", b =>
                {
                    b.Navigation("ID_Ile");

                    b.Navigation("ID_Mer");

                    b.Navigation("ID_Monde");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Ile", b =>
                {
                    b.Navigation("ID_Village");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Mer", b =>
                {
                    b.Navigation("Liste_Iles");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Monde", b =>
                {
                    b.Navigation("Liste_Mers");

                    b.Navigation("Monde_Parametrage");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Utilisateur", b =>
                {
                    b.Navigation("ID_Liste_Villages");

                    b.Navigation("ID_Monde");
                });

            modelBuilder.Entity("L3Projet.Common.Models.Village", b =>
                {
                    b.Navigation("Liste_Batiment");

                    b.Navigation("Liste_Cout_Ressources");
                });
#pragma warning restore 612, 618
        }
    }
}
