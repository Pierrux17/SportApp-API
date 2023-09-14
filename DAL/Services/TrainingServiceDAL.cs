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
    public class TrainingServiceDAL : ITrainingRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TrainingServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public TrainingDAL Create(TrainingDAL t)
        {
            _context.Training.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TrainingDAL t)
        {
            _context.Training.Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<TrainingDAL> GetAll()
        {
            return _context.Training.ToList();
        }

        public TrainingDAL GetById(int id)
        {
            return _context.Training.Find(id);
        }

        public void Update(TrainingDAL t)
        {
            TrainingDAL newTraining = _context.Training.Find(t.Id);
            if (newTraining == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newTraining.Name = t.Name;
            newTraining.Description = t.Description;
            newTraining.Picture = t.Picture;

            _context.Entry(newTraining).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TrainingDAL GetLastTrainingCreated()
        {
            return _context.Training.OrderByDescending(p => p.Id).FirstOrDefault();
        }
    }
}
