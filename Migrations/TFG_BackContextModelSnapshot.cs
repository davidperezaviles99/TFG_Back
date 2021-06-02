﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TFG_Back.Data;

namespace TFG_Back.Migrations
{
    [DbContext(typeof(TFG_BackContext))]
    partial class TFG_BackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TFG_Back.Models.Asignatura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("Codigo")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long?>("ProfesorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Asignatura");
                });

            modelBuilder.Entity("TFG_Back.Models.Curso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AsignaturaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("TFG_Back.Models.Diario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AsignaturaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<long?>("EquipoId")
                        .HasColumnType("bigint");

                    b.Property<string>("EvaluacionP")
                        .HasColumnType("text");

                    b.Property<string>("EvaluacionT")
                        .HasColumnType("text");

                    b.Property<long>("Horas")
                        .HasMaxLength(2)
                        .HasColumnType("bigint");

                    b.Property<string>("Link")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AsignaturaId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("UserId");

                    b.ToTable("Diario");
                });

            modelBuilder.Entity("TFG_Back.Models.Equipo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("AlumnoId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProfesorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TutorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("ProfesorId");

                    b.HasIndex("TutorId");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("TFG_Back.Models.Evaluacion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("EquipoId")
                        .HasColumnType("bigint");

                    b.Property<string>("EvaluacionP")
                        .HasColumnType("text");

                    b.Property<string>("EvaluacionT")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.ToTable("Evaluacion");
                });

            modelBuilder.Entity("TFG_Back.Models.Mensaje", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<long?>("EquipoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

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

                    b.Property<long?>("CursoId")
                        .HasColumnType("bigint");

                    b.HasIndex("CursoId");

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

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("TFG_Back.Models.Asignatura", b =>
                {
                    b.HasOne("TFG_Back.Models.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("TFG_Back.Models.Curso", b =>
                {
                    b.HasOne("TFG_Back.Models.Asignatura", "Asignatura")
                        .WithMany()
                        .HasForeignKey("AsignaturaId");

                    b.Navigation("Asignatura");
                });

            modelBuilder.Entity("TFG_Back.Models.Diario", b =>
                {
                    b.HasOne("TFG_Back.Models.Asignatura", "Asignatura")
                        .WithMany()
                        .HasForeignKey("AsignaturaId");

                    b.HasOne("TFG_Back.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("TFG_Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Asignatura");

                    b.Navigation("Equipo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFG_Back.Models.Equipo", b =>
                {
                    b.HasOne("TFG_Back.Models.Alumno", "Alumno")
                        .WithMany("Equipo")
                        .HasForeignKey("AlumnoId");

                    b.HasOne("TFG_Back.Models.Profesor", "Profesor")
                        .WithMany("Equipo")
                        .HasForeignKey("ProfesorId");

                    b.HasOne("TFG_Back.Models.Tutor", "Tutor")
                        .WithMany("Equipo")
                        .HasForeignKey("TutorId");

                    b.Navigation("Alumno");

                    b.Navigation("Profesor");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TFG_Back.Models.Evaluacion", b =>
                {
                    b.HasOne("TFG_Back.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("TFG_Back.Models.Mensaje", b =>
                {
                    b.HasOne("TFG_Back.Models.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("TFG_Back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Equipo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TFG_Back.Models.Alumno", b =>
                {
                    b.HasOne("TFG_Back.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("TFG_Back.Models.Alumno", b =>
                {
                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("TFG_Back.Models.Profesor", b =>
                {
                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("TFG_Back.Models.Tutor", b =>
                {
                    b.Navigation("Equipo");
                });
#pragma warning restore 612, 618
        }
    }
}
