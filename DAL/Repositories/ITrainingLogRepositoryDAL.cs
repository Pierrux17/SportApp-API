using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ITrainingLogRepositoryDAL
    {
        TrainingLogDAL Create(TrainingLogDAL t);
        IEnumerable<TrainingLogDAL> GetAll();
        TrainingLogDAL GetById(int id);
        TrainingLogDAL Update(TrainingLogDAL t);
        void Delete(TrainingLogDAL t);
    }
}
