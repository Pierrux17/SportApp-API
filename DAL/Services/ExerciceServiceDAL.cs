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
    public class ExerciceServiceDAL : IExerciceRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public ExerciceServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public ExerciceDAL Create(ExerciceDAL e)
        {
            _context.Exercice.Add(e);
            _context.SaveChanges();
            return e;
        }

        public void Delete(ExerciceDAL e)
        {
            _context.Exercice.Remove(e);
            _context.SaveChanges();
        }

        public IEnumerable<ExerciceDAL> GetAll()
        {
            return _context.Exercice.ToList();
        }

        public ExerciceDAL GetById(int id)
        {
            return _context.Exercice.Find(id);
        }

        public ExerciceDAL Update(ExerciceDAL e)
        {
            ExerciceDAL newE = _context.Exercice.Find(e.Id);
            if (newE == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newE.Name = e.Name;
            newE.Description = e.Description;
            newE.Picture = e.Picture;
            newE.Id_type_exercice = e.Id_type_exercice;

            _context.Entry(newE).State = EntityState.Modified;
            _context.SaveChanges();

            return newE;
        }
    }
}
