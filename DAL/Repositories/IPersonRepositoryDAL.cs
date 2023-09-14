using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPersonRepositoryDAL
    {
        PersonDAL Create(PersonDAL p);
        IEnumerable<PersonDAL> GetAll();
        PersonDAL GetById(int id);
        PersonDAL Update(PersonDAL p);
        void Delete(PersonDAL p);

        PersonDAL Login(string login, string password);
    }
}
