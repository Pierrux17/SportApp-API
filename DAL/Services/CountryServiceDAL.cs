using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CountryServiceDAL : ICountryRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public CountryServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public CountryDAL Create(CountryDAL c)
        {
            _context.Country.Add(c);
            _context.SaveChanges();
            return c;
        }

        public void Delete(CountryDAL c)
        {
            _context.Country.Remove(c);
            _context.SaveChanges();
        }

        public IEnumerable<CountryDAL> GetAll()
        {
            return _context.Country.ToList();
        }

        public CountryDAL GetById(int id)
        {
            return _context.Country.Find(id);
        }

        public CountryDAL Update(CountryDAL c)
        {
            CountryDAL newC = _context.Country.Find(c.Id);
            if (newC == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            //newC.Id = c.Id;
            newC.Name = c.Name;

            _context.Entry(newC).State = EntityState.Modified;
            _context.SaveChanges();

            return newC;
        }
    }
}
