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
    public class TypeExerciceServiceDAL : ITypeExerciceRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public TypeExerciceServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public TypeExerciceDAL Create(TypeExerciceDAL t)
        {
            _context.Type_Exercice.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Delete(TypeExerciceDAL t)
        {
            _context.Type_Exercice.Remove(t);
            _context.SaveChanges();
        }

        public IEnumerable<TypeExerciceDAL> GetAll()
        {
            return _context.Type_Exercice.ToList();
        }

        public TypeExerciceDAL GetById(int id)
        {
            return _context.Type_Exercice.Find(id);
        }

        public TypeExerciceDAL Update(TypeExerciceDAL t)
        {
            TypeExerciceDAL newT = _context.Type_Exercice.Find(t.Id);
            if(newT == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newT.Name = t.Name;
            newT.Picture = t.Picture;
            newT.Id_sort_exercice = t.Id_sort_exercice;

            _context.Entry(newT).State = EntityState.Modified;
            _context.SaveChanges();

            return t;
        }
    }
}
