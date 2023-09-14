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
    public class ProfilServiceDAL : IProfilRepositoryDAL
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public ProfilServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public ProfilDAL Create(ProfilDAL p)
        {
            _context.Profil.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(ProfilDAL p)
        {
            _context.Profil.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<ProfilDAL> GetAll()
        {
            return _context.Profil.ToList();
        }

        public ProfilDAL GetById(int id)
        {
            return _context.Profil.Find(id);
        }

        public ProfilDAL GetByIdPerson(int id)
        {
            return _context.Profil.FirstOrDefault(p => p.Id_person == id);
        }

        public ProfilDAL Update(ProfilDAL p)
        {
            ProfilDAL newP = _context.Profil.Find(p.Id);
            if (newP == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newP.Age = p.Age;
            newP.Height = p.Height;
            newP.Weight = p.Weight;
            newP.Total_xp = p.Total_xp;
            newP.Id_person = p.Id_person;

            _context.Entry(newP).State = EntityState.Modified;
            _context.SaveChanges();

            return newP;
        }
    }
}
