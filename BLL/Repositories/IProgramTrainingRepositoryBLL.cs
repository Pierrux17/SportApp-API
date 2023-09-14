using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IProgramTrainingRepositoryBLL
    {
        IEnumerable<ProgramTrainingBLL> GetByIdProgram(int id);
        ProgramTrainingBLL Create(ProgramTrainingBLL p);

        IEnumerable<ProgramTrainingBLL> GetAll();
        ProgramTrainingBLL GetById(int id_program, int id_training);
        void Delete(ProgramTrainingBLL p);
    }
}
