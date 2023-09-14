using BLL.Models;
using BLL.Repositories;
using BLL.Tools;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProgramTrainingServiceBLL : IProgramTrainingRepositoryBLL
    {
        private readonly IProgramTrainingRepositoryDAL _programTrainingRepositoryDAL;
        private readonly IProgramRepositoryDAL _programRepositoryDAL;
        private readonly ITrainingRepositoryDAL _trainingRepositoryDAL;

        public ProgramTrainingServiceBLL(IProgramTrainingRepositoryDAL programTrainingRepositoryDAL, IProgramRepositoryDAL programRepositoryDAL, ITrainingRepositoryDAL trainingRepositoryDAL)
        {
            _programTrainingRepositoryDAL = programTrainingRepositoryDAL;
            _programRepositoryDAL = programRepositoryDAL;
            _trainingRepositoryDAL = trainingRepositoryDAL;
        }

        public ProgramTrainingBLL Create(ProgramTrainingBLL p)
        {
            _programTrainingRepositoryDAL.Create(Mappers.ToDAL(p));
            return p;
        }

        public void Delete(ProgramTrainingBLL p)
        {
            _programTrainingRepositoryDAL.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<ProgramTrainingBLL> GetAll()
        {
            return _programTrainingRepositoryDAL.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public ProgramTrainingBLL GetById(int id_program, int id_training)
        {
            return Mappers.ToBLL(_programTrainingRepositoryDAL.GetById(id_program, id_training));
        }

        public IEnumerable<ProgramTrainingBLL> GetByIdProgram(int id)
        {
            ProgramBLL program = Mappers.ToBLL(_programRepositoryDAL.GetById(id));
            IEnumerable<ProgramTrainingBLL> list = _programTrainingRepositoryDAL.GetAll().Where(p => p.Id_program == program.Id).Select(x => Mappers.ToBLL(x));
            return list;
        }
    }
}
