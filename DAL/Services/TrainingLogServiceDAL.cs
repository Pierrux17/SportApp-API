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
    public class TrainingLogServiceDAL : ITrainingLogRepositoryDAL
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TrainingLogServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public TrainingLogDAL Create(TrainingLogDAL t)
        {
            _context.Training_Log.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TrainingLogDAL t)
        {
            _context.Training_Log.Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<TrainingLogDAL> GetAll()
        {
            return _context.Training_Log.ToList();
        }

        public TrainingLogDAL GetById(int id)
        {
            return _context.Training_Log.Find(id);
        }

        public TrainingLogDAL Update(TrainingLogDAL t)
        {
            TrainingLogDAL newT = _context.Training_Log.Find(t.Id);
            if (newT == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newT.Id = t.Id;
            newT.Date = t.Date;
            newT.Id_person = t.Id_person;
            newT.Id_training = t.Id_training;

            _context.Entry(newT).State = EntityState.Modified;
            _context.SaveChanges();

            return newT;
        }
    }
}
