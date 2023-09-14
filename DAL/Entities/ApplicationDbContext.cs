using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationDbContext : DbContext
    {
        private string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonProgramDAL>().HasKey(p => new { p.Id_person, p.Id_program });
            modelBuilder.Entity<ProgramTrainingDAL>().HasKey(p => new { p.Id_program, p.Id_training });
            modelBuilder.Entity<TrainingExerciceDAL>().HasKey(t => new { t.Id_training, t.Id_exercice });
            modelBuilder.Entity<ProfilSuccessDAL>().HasKey(p => new { p.Id_profil, p.Id_success });
            modelBuilder.Entity<ProfilTypeGoalDAL>().HasKey(p => new { p.Id_profil, p.Id_typegoal });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<CountryDAL> Country { get; set; }
        public DbSet<PersonDAL> Person { get; set; }
        public DbSet<TypePersonDAL> Type_Person { get; set; }
        public DbSet<TypeProgramDAL> Type_Program { get; set; }
        public DbSet<ProgramDAL> Program { get; set; }
        public DbSet<SortExerciceDAL> Sort_Exercice { get; set; }
        public DbSet<TypeExerciceDAL> Type_Exercice { get; set; }
        public DbSet<ExerciceDAL> Exercice { get; set; }
        public DbSet<TrainingDAL> Training { get; set; }
        public DbSet<ProfilDAL> Profil { get; set; }
        public DbSet<PerformanceDAL> Performance { get; set; }
        public DbSet<SuccessDAL> Success { get; set; }
        public DbSet<PersonProgramDAL> Person_Program { get; set; }
        public DbSet<ProgramTrainingDAL> Program_Training { get; set; }
        public DbSet<TrainingExerciceDAL> Training_Exercice { get; set; }
        public DbSet<ProfilSuccessDAL> Profil_Success { get; set; }
        public DbSet<ProfilTypeGoalDAL> Profil_TypeGoal { get; set; }
        public DbSet<TrainingLogDAL> Training_Log { get; set; }
        public DbSet<ExerciceLogDAL> Exercice_Log { get; set; }

    }
}
