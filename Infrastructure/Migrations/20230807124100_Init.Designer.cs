﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infrastructure;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PatientDbcontext))]
    [Migration("20230807124100_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Domain.Injury", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("treatement")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("injuries");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("InjuryPatient", b =>
                {
                    b.Property<int>("Injuriesid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Injuriesid", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("InjuryPatient");
                });

            modelBuilder.Entity("InjuryPatient", b =>
                {
                    b.HasOne("Domain.Injury", null)
                        .WithMany()
                        .HasForeignKey("Injuriesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}