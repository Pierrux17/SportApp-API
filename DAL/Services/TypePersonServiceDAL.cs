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
    public class TypePersonServiceDAL : ITypePersonRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TypePersonServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public TypePersonDAL Create(TypePersonDAL t)
        {
            _context.Type_Person.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TypePersonDAL t)
        {
            _context.Type_Person.Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<TypePersonDAL> GetAll()
        {
            return _context.Type_Person.ToList();
        }

        public TypePersonDAL GetById(int id)
        {
            return _context.Type_Person.Find(id);
        }

        public TypePersonDAL Update(TypePersonDAL t)
        {
            TypePersonDAL newT = _context.Type_Person.Find(t.Id);
            if (newT == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newT.Name = t.Name;

            _context.Entry(newT).State = EntityState.Modified;
            _context.SaveChanges();

            return t;
        }
    }
}
