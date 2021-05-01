﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TFG_Back.Data;

namespace TFG_Back.Migrations
{
    [DbContext(typeof(TFG_BackContext))]
    [Migration("20210430182537_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AlumnoProfesor", b =>
                {
                    b.Property<long>("AlumnoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfesorId")
                        .HasColumnType("bigint");

                    b.HasKey("AlumnoId", "ProfesorId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("AlumnoProfesor");
                });

            modelBuilder.Entity("TFG_Back.Models.Asignaturas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Asignatura")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("Codigo")
                        .HasMaxLength(30)
                        .HasColumnType("bigint");

                    b.Property<string>("Curso")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("TFG_Back.Models.Diario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AlumnoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("AsignaturasId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("EvaluacionP")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("EvaluacionT")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<long>("Horas")
                        .HasMaxLength(3)
                        .HasColumnType("bigint");

                    b.Property<string>("LinkExterno")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("AsignaturasId");

                    b.ToTable("Diario");
                });

            modelBuilder.Entity("TFG_Back.Models.Mensaje", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Mensaje");
                });

            modelBuilder.Entity("TFG_Back.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TFG_Back.Models.Alumno", b =>
                {
                    b.HasBaseType("TFG_Back.Models.User");

                    b.Property<long?>("TutorId")
                        .HasColumnType("bigint");

                    b.HasIndex("TutorId");

                    b.HasDiscriminator().HasValue("Alumno");
                });

            modelBuilder.Entity("TFG_Back.Models.Profesor", b =>
                {
                    b.HasBaseType("TFG_Back.Models.User");

                    b.HasDiscriminator().HasValue("Profesor");
                });

            modelBuilder.Entity("TFG_Back.Models.Tutor", b =>
                {
                    b.HasBaseType("TFG_Back.Models.User");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("AlumnoProfesor", b =>
                {
                    b.HasOne("TFG_Back.Models.Alumno", null)
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFG_Back.Models.Profesor", null)
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TFG_Back.Models.Diario", b =>
                {
                    b.HasOne("TFG_Back.Models.Alumno", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId");

                    b.HasOne("TFG_Back.Models.Asignaturas", "Asignaturas")
                        .WithMany()
                        .HasForeignKey("AsignaturasId");

                    b.Navigation("Alumno");

                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("TFG_Back.Models.Mensaje", b =>
                {
                    b.HasOne("TFG_Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFG_Back.Models.Alumno", b =>
                {
                    b.HasOne("TFG_Back.Models.Tutor", "Tutor")
                        .WithMany("Alumno")
                        .HasForeignKey("TutorId");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TFG_Back.Models.Tutor", b =>
                {
                    b.Navigation("Alumno");
                });
#pragma warning restore 612, 618
        }
    }
}