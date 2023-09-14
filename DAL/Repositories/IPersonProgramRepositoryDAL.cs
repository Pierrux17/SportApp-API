using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPersonProgramRepositoryDAL
    {
        PersonProgramDAL Create(PersonProgramDAL p);
        IEnumerable<PersonProgramDAL> GetAll();
        PersonProgramDAL GetById(int id_person, int id_program);
        PersonProgramDAL Update(PersonProgramDAL p);
        void Delete(PersonProgramDAL p);
    }
}
