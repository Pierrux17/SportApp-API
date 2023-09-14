using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProgramTrainingRepositoryDAL
    {
        ProgramTrainingDAL Create(ProgramTrainingDAL p);
        IEnumerable<ProgramTrainingDAL> GetAll();
        ProgramTrainingDAL GetById(int id_program, int id_training);
        ProgramTrainingDAL Update(ProgramTrainingDAL p);
        void Delete(ProgramTrainingDAL p);
    }
}
