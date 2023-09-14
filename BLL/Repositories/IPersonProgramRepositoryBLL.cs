using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IPersonProgramRepositoryBLL
    {
        IEnumerable<PersonProgramBLL> GetProgramsUsedByPerson(int id);
        PersonProgramBLL Create(PersonProgramBLL p);

        IEnumerable<PersonProgramBLL> GetAll();
        PersonProgramBLL GetById(int id_person, int id_program);
        void Delete(PersonProgramBLL p);
    }
}
