using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class TrainingExerciceServiceDAL : ITrainingExerciceRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TrainingExerciceServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public TrainingExerciceDAL Create(TrainingExerciceDAL t)
        {
            // Obtenir la valeur maximale actuelle de "cpt"
            int currentMaxCpt = _context.Training_Exercice.Max(te => te.Cpt);

            // Incrémenter la valeur de "cpt" pour la nouvelle ligne
            t.Cpt = currentMaxCpt + 1;

            _context.Training_Exercice.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TrainingExerciceDAL t)
        {
            _context.Training_Exercice.Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<TrainingExerciceDAL> GetAll()
        {
            return _context.Training_Exercice.ToList();
        }

        public TrainingExerciceDAL GetById(int id_training, int id_exercice)
        {
            return _context.Training_Exercice.FirstOrDefault(t => t.Id_training == id_training && t.Id_exercice == id_exercice);
        }

        public TrainingExerciceDAL Update(TrainingExerciceDAL t)
        {
            TrainingExerciceDAL newT = _context.Training_Exercice.Find(t.Id_training, t.Id_exercice);
            if (newT == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newT.Id_training = t.Id_training;
            newT.Id_exercice = t.Id_exercice;
            newT.Serie = t.Serie;
            newT.Reps = t.Reps;
            newT.Weight = t.Weight;
            newT.Rest = t.Rest;
            newT.Rpe = t.Rpe;
            newT.Distance = t.Distance;
            newT.Time = t.Time;

            _context.Entry(newT).State = EntityState.Modified;
            _context.SaveChanges();

            return newT;
        }
    }
}
