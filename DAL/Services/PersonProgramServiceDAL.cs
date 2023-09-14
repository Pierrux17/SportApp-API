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
    public class PersonProgramServiceDAL : IPersonProgramRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public PersonProgramServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }

        public PersonProgramDAL Create(PersonProgramDAL p)
        {
            _context.Person_Program.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(PersonProgramDAL p)
        {
            _context.Person_Program.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<PersonProgramDAL> GetAll()
        {
            return _context.Person_Program.ToList();
        }

        public PersonProgramDAL GetById(int id_person, int id_program)
        {
            //return _context.PersonProgram.Find(id);
            return _context.Person_Program.FirstOrDefault(p => p.Id_person == id_person && p.Id_program == id_program);
        }

        public PersonProgramDAL Update(PersonProgramDAL p)
        {
            PersonProgramDAL newP = _context.Person_Program.Find(p.Id_person, p.Id_program);
            if (newP == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newP.Id_person = p.Id_person;
            newP.Id_program = p.Id_program;

            _context.Entry(newP).State = EntityState.Modified;
            _context.SaveChanges();

            return newP;
        }
    }
}
