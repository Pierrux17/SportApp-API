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
    public class TypeProgramServiceDAL : ITypeProgramRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TypeProgramServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }

        public TypeProgramDAL Create(TypeProgramDAL t)
        {
            _context.Type_Program.Add(t);
            _context.SaveChanges();
            return t;
        }

        public IEnumerable<TypeProgramDAL> GetAll()
        {
            return _context.Type_Program.ToList();
        }

        public TypeProgramDAL GetById(int id)
        {
            return _context.Type_Program.Find(id);
        }

        public TypeProgramDAL Update(TypeProgramDAL t)
        {
            TypeProgramDAL newT = _context.Type_Program.Find(t.Id);
            if (newT == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newT.Name = t.Name;
            newT.Picture = t.Picture;

            _context.Entry(newT).State = EntityState.Modified;
            _context.SaveChanges();

            return t;
        }

        public void Delete(TypeProgramDAL t)
        {
            _context.Type_Program.Remove(t);
            _context.SaveChanges();
        }
    }
}
