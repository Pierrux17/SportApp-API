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
    public class ProgramTrainingServiceDAL : IProgramTrainingRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public ProgramTrainingServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }

        public ProgramTrainingDAL Create(ProgramTrainingDAL p)
        {
            _context.Program_Training.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(ProgramTrainingDAL p)
        {
            _context.Program_Training.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<ProgramTrainingDAL> GetAll()
        {
            return _context.Program_Training.ToList();
        }

        public ProgramTrainingDAL GetById(int id_program, int id_training)
        {
            //return _context.ProgramTraining.Find(id);
            return _context.Program_Training.FirstOrDefault(p => p.Id_program == id_program && p.Id_training == id_training);
        }

        public ProgramTrainingDAL Update(ProgramTrainingDAL p)
        {
            ProgramTrainingDAL newP = _context.Program_Training.Find(p.Id_program, p.Id_training);
            if (newP == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newP.Id_program = p.Id_program;
            newP.Id_training = p.Id_training;

            _context.Entry(newP).State = EntityState.Modified;
            _context.SaveChanges();

            return newP;
        }
    }
}
