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
    public class PerformanceServiceDAL : IPerformanceRepositoryDAL
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public PerformanceServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public PerformanceDAL Create(PerformanceDAL p)
        {
            _context.Performance.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(PerformanceDAL p)
        {
            _context.Performance.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<PerformanceDAL> GetAll()
        {
            return _context.Performance.ToList();
        }

        public PerformanceDAL GetById(int id)
        {
            return _context.Performance.Find(id);
        }

        public PerformanceDAL Update(PerformanceDAL p)
        {
            PerformanceDAL newP = _context.Performance.Find(p.Id);
            if (newP == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newP.Description = p.Description;
            newP.Value = p.Value;
            newP.Date = DateTime.Now;
            newP.Id_profil = p.Id_profil;
            newP.Id_exercice = p.Id_exercice;

            _context.Entry(newP).State = EntityState.Modified;
            _context.SaveChanges();

            return newP;
        }
    }
}
