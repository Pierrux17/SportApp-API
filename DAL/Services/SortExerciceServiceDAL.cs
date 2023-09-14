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
    public class SortExerciceServiceDAL : ISortExerciceRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public SortExerciceServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public SortExerciceDAL Create(SortExerciceDAL s)
        {
            _context.Sort_Exercice.Add(s);
            _context.SaveChanges();
            return s;
        }

        public void Delete(SortExerciceDAL s)
        {
            _context.Sort_Exercice.Remove(s);
            _context.SaveChanges();
        }

        public IEnumerable<SortExerciceDAL> GetAll()
        {
            return _context.Sort_Exercice.ToList();
        }

        public SortExerciceDAL GetById(int id)
        {
            return _context.Sort_Exercice.Find(id);
        }

        public SortExerciceDAL Update(SortExerciceDAL s)
        {
            SortExerciceDAL newS = _context.Sort_Exercice.Find(s.Id);
            if (newS == null) 
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newS.Name = s.Name;
            newS.Picture = s.Picture;

            _context.Entry(newS).State = EntityState.Modified;
            _context.SaveChanges();

            return newS;
        }
    }
}
