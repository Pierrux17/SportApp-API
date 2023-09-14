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
    public class PersonServiceDAL : IPersonRepositoryDAL
    {
        //private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=workoutdb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=bwdb;Trusted_Connection=True;TrustServerCertificate=True;";

        private readonly ApplicationDbContext _context;

        public PersonServiceDAL()
        {
            _context = new ApplicationDbContext(_connectionString);
        }
        public PersonDAL Create(PersonDAL p)
        {
            _context.Person.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Delete(PersonDAL p)
        {
            _context.Person.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<PersonDAL> GetAll()
        {
            return _context.Person.ToList();
         }

        public PersonDAL GetById(int id)
        {
            return _context.Person.Find(id);
        }

        /*public PersonDAL Update(PersonDAL p)
        {
            PersonDAL newPerson = _context.Person.Find(p.Id);
            if (newPerson == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            newPerson.Lastname = p.Lastname;
            newPerson.Firstname = p.Firstname;
            newPerson.Mail = p.Mail;
            newPerson.Login = p.Login;
            newPerson.Password = p.Password;
            newPerson.Password_reset_token = p.Password_reset_token;
            newPerson.Created_at = p.Created_at;
            newPerson.Updated_at = p.Updated_at;
            newPerson.Is_validate = p.Is_validate;
            newPerson.Id_type_person = p.Id_type_person;
            newPerson.Id_country = p.Id_country;

            _context.SaveChanges();

            return newPerson;
        }*/

        public PersonDAL Update(PersonDAL p)
        {
            PersonDAL newPerson = _context.Person.Find(p.Id);
            if (newPerson == null)
            {
                throw new ArgumentException("L'entité à mettre à jour n'existe pas dans la base de données.");
            }

            // Exclure les champs de la mise à jour
            p.Created_at = newPerson.Created_at;
            p.Password_reset_token = newPerson.Password_reset_token;
            //p.Password = newPerson.Password;
            p.Auth_key = newPerson.Auth_key;

            newPerson.Lastname = p.Lastname;
            newPerson.Firstname = p.Firstname;
            newPerson.Mail = p.Mail;
            newPerson.Login = p.Login;
            newPerson.Updated_at = p.Updated_at;
            newPerson.Is_validate = p.Is_validate;
            newPerson.Id_type_person = p.Id_type_person;
            newPerson.Id_country = p.Id_country;
            newPerson.Password = p.Password;

            _context.Entry(newPerson).State = EntityState.Modified;
            _context.SaveChanges();

            return newPerson;
        }

        public PersonDAL Login(string login, string password)
        {
            LoginDAL loginData = new LoginDAL
            {
                Login = login,
                Password = password
            };

            PersonDAL person = _context.Person.FirstOrDefault(p => p.Login == loginData.Login && p.Password == loginData.Password);

            if(person == null)
            {
                throw new ArgumentException("Login ou mot de passe incorrect");
            }

            return person;
        }
    }
}
