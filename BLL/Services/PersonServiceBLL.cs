using BLL.Models;
using BLL.Repositories;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Tools;

namespace BLL.Services
{
    public class PersonServiceBLL : IPersonRepositoryBLL<PersonBLL>
    {
        private readonly IPersonRepositoryDAL _personRepositoryDAL;

        public PersonServiceBLL(IPersonRepositoryDAL personRepositoryDAL)
        {
            _personRepositoryDAL = personRepositoryDAL;
        }

        public PersonBLL Create(PersonBLL p)
        {
            p.Password_reset_token = null;
            p.Auth_key = Generate.GenerateRandomString(32);
            //p.Auth_key = "test";
            p.Created_at = DateTime.Now;
            p.Updated_at = null;
            p.Is_validate = false;
            p.Id_type_person = 2; //Automatiquement User 
            _personRepositoryDAL.Create(Mappers.ToDAL(p));

            return p;
        }

        public void Delete(PersonBLL p)
        {
            if (p.Id_type_person == 1)
            {
                throw new ArgumentException("Impossible de supprimer l'admin");
            }

            _personRepositoryDAL.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<PersonBLL> GetAll()
        {
            return _personRepositoryDAL.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public PersonBLL GetById(int id)
        {
            return Mappers.ToBLL(_personRepositoryDAL.GetById(id));
        }

        public PersonBLL Login(LoginBLL l)
        {
            PersonBLL p = Mappers.ToBLL(_personRepositoryDAL.Login(l.Login, l.Password));
            if (p == null || !string.Equals(p.Login, l.Login, StringComparison.Ordinal) || !string.Equals(p.Password, l.Password, StringComparison.Ordinal))
            {
                throw new ArgumentException("Login or password incorrect");
            }
            return p;
        }

        //public PersonBLL Login(LoginBLL l)
        //{
        //    PersonBLL p = Mappers.ToBLL(_personRepositoryDAL.Login(l.Login, l.Password));

        //    // Compare the provided password with the hashed password using BCrypt's Verify method
        //    if (p == null || !string.Equals(p.Login, l.Login, StringComparison.Ordinal) ||
        //        !BCrypt.Net.BCrypt.Verify(l.Password, p.Password))
        //    {
        //        throw new ArgumentException("Login or password incorrect");
        //    }

        //    return p;
        //}


        public void Update(PersonBLL p)
        {
            p.Updated_at = DateTime.Now;
            _personRepositoryDAL.Update(Mappers.ToDAL(p));        
        }
    }
}
