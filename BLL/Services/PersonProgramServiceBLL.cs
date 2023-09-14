using BLL.Models;
using BLL.Repositories;
using BLL.Tools;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonProgramServiceBLL : IPersonProgramRepositoryBLL
    {
        private readonly IPersonProgramRepositoryDAL _personProgramRepositoryDAL;
        private readonly IProgramRepositoryDAL _programRepositoryDAL;
        private readonly IPersonRepositoryDAL _personRepositoryDAL;

        public PersonProgramServiceBLL(IPersonProgramRepositoryDAL personProgramRepositoryDAL, IProgramRepositoryDAL programRepositoryDAL, IPersonRepositoryDAL personRepositoryDAL)
        {
            _personProgramRepositoryDAL = personProgramRepositoryDAL;
            _programRepositoryDAL = programRepositoryDAL;
            _personRepositoryDAL = personRepositoryDAL;
        }

        public PersonProgramBLL Create(PersonProgramBLL p)
        {
            _personProgramRepositoryDAL.Create(Mappers.ToDAL(p));
            return p;
        }

        public void Delete(PersonProgramBLL p)
        {
            _personProgramRepositoryDAL.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<PersonProgramBLL> GetAll()
        {
            return _personProgramRepositoryDAL.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public PersonProgramBLL GetById(int id_person, int id_program)
        {
            return Mappers.ToBLL(_personProgramRepositoryDAL.GetById(id_person, id_program));
        }

        public IEnumerable<PersonProgramBLL> GetProgramsUsedByPerson(int id)
        {            
            PersonBLL person = Mappers.ToBLL(_personRepositoryDAL.GetById(id));
            
            IEnumerable<PersonProgramBLL> list = _personProgramRepositoryDAL.GetAll().Where(p => p.Id_person == person.Id).Select(x => Mappers.ToBLL(x));
            return list;
        }
    }
}
