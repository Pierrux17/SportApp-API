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
    public class ProgramServiceDAL : IProgramRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public ProgramServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public ProgramDAL Create(ProgramDAL p)
        {
            _context.Program.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(ProgramDAL p)
        {
            _context.Program.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<ProgramDAL> GetAll()
        {
            return _context.Program.ToList();
        }

        public ProgramDAL GetById(int id)
        {
            return _context.Program.Find(id);
        }

        public ProgramDAL Update(ProgramDAL p)
        {
            ProgramDAL newP = _context.Program.Find(p.Id);
            if(newP == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newP.Name = p.Name;
            newP.Nbtrainingperweek = p.Nbtrainingperweek;
            newP.Duration = p.Duration;
            newP.Objectif = p.Objectif;
            newP.Id_type_program = p.Id_type_program;
            newP.Is_my_Program = p.Is_my_Program;
            newP.Created_by = p.Created_by;

            _context.Entry(newP).State = EntityState.Modified;
            _context.SaveChanges();

            return newP;
        }

        public ProgramDAL GetLastProgramCreated(int id)
        {
            return _context.Program.Where(p => p.Created_by == id).OrderByDescending(p => p.Id).FirstOrDefault();
        }

    }
}
