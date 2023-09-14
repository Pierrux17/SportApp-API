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
    public class ProgramServiceBLL : IProgramRepositoryBLL<ProgramBLL>
    {
        private readonly IProgramRepositoryDAL _programRepositoryDAL;

        public ProgramServiceBLL(IProgramRepositoryDAL programRepositoryDAL)
        {
            _programRepositoryDAL = programRepositoryDAL;
        }

        public ProgramBLL Create(ProgramBLL p, int id_person)
        {
            p.Created_by = id_person;

            _programRepositoryDAL.Create(Mappers.ToDAL(p));
            return p;
        }

        public void Delete(ProgramBLL p)
        {
            _programRepositoryDAL.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<ProgramBLL> GetAll()
        {
            return _programRepositoryDAL.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public IEnumerable<ProgramBLL> GetAllMyPrograms(int id_person)
        {
            // Afficher si Is_my_program = false OU si Is_my_program = true et Created_by = id_person
            // Un utilisateur ne peut voir que les programs "publiques" et ceux qu'il a créé
            return _programRepositoryDAL.GetAll().Where(p => p.Is_my_Program == true && p.Created_by == id_person || p.Is_my_Program == false)
                                                .Select(p => Mappers.ToBLL(p));
        }


        public ProgramBLL GetById(int id)
        {
            return Mappers.ToBLL(_programRepositoryDAL.GetById(id));
        }

        public void Update(ProgramBLL p)
        {
            _programRepositoryDAL.Update(Mappers.ToDAL(p));
        }

        public ProgramBLL GetLastProgramCreated(int id)
        {
            return Mappers.ToBLL(_programRepositoryDAL.GetLastProgramCreated(id));
        }
    }
}
