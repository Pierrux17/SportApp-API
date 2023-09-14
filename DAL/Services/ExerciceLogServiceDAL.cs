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
    public class ExerciceLogServiceDAL : IExerciceLogRepositoryDAL
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public ExerciceLogServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public ExerciceLogDAL Create(ExerciceLogDAL e)
        {
            _context.Exercice_Log.Add(e);
            _context.SaveChanges();
            return e;
        }

        public void Delete(ExerciceLogDAL e)
        {
            _context.Exercice_Log.Remove(e);
            _context.SaveChanges();
        }

        public IEnumerable<ExerciceLogDAL> GetAll()
        {
            return _context.Exercice_Log.ToList();
        }

        public ExerciceLogDAL GetById(int id)
        {
            return _context.Exercice_Log.Find(id);
        }

        public ExerciceLogDAL Update(ExerciceLogDAL e)
        {
            ExerciceLogDAL newE = _context.Exercice_Log.Find(e.Id);
            if (newE == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newE.Id = e.Id;
            newE.Reps = e.Reps;
            newE.Weight = e.Weight;
            newE.Distance = e.Distance;
            newE.Time = e.Time;
            newE.Comment = e.Comment;
            newE.Id_training_log = e.Id_training_log;
            newE.Id_exercice = e.Id_exercice;

            _context.Entry(newE).State = EntityState.Modified;
            _context.SaveChanges();

            return newE;
        }
    }
}
