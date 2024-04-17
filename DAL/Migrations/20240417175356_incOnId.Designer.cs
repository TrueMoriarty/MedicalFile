﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MedicalFileContext))]
    [Migration("20240417175356_incOnId")]
    partial class incOnId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Anamnesis")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Symptoms")
                        .HasColumnType("text");

                    b.Property<string>("Treatment")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("DAL.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RiskFactor")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DAL.Models.Disease", b =>
                {
                    b.HasOne("DAL.Models.Patient", "Patient")
                        .WithMany("Diseases")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DAL.Models.Patient", b =>
                {
                    b.Navigation("Diseases");
                });
#pragma warning restore 612, 618
        }
    }
}
