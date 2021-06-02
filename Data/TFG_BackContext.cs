using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Models;

namespace TFG_Back.Data
{
    public class TFG_BackContext : DbContext
    {
        public TFG_BackContext(DbContextOptions<TFG_BackContext> options)
            : base(options)
        {
        }

        public DbSet<TFG_Back.Models.User> User { get; set; }

        public DbSet<TFG_Back.Models.Profesor> Profesor { get; set; }

        public DbSet<TFG_Back.Models.Tutor> Tutor { get; set; }

        public DbSet<TFG_Back.Models.Alumno> Alumno { get; set; }

        public DbSet<TFG_Back.Models.Equipo> Equipo { get; set; }

        public DbSet<TFG_Back.Models.Evaluacion> Evaluacion { get; set; }

        public DbSet<TFG_Back.Models.Mensaje> Mensaje { get; set; }

        public DbSet<TFG_Back.Models.Curso> Curso { get; set; }
        public DbSet<TFG_Back.Models.Diario> Diario { get; set; }

        public DbSet<TFG_Back.Models.Asignatura> Asignatura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }

   
  }
