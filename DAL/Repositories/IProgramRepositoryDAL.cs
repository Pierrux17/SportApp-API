using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProgramRepositoryDAL
    {
        ProgramDAL Create(ProgramDAL p);
        IEnumerable<ProgramDAL> GetAll();
        ProgramDAL GetById(int id);
        ProgramDAL Update(ProgramDAL p);
        void Delete(ProgramDAL p);
        ProgramDAL GetLastProgramCreated(int id);
    }
}
