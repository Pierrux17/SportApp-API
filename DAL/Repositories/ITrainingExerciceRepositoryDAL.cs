using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ITrainingExerciceRepositoryDAL
    {
        TrainingExerciceDAL Create(TrainingExerciceDAL t);
        IEnumerable<TrainingExerciceDAL> GetAll();
        TrainingExerciceDAL GetById(int id_training, int id_exercice);
        TrainingExerciceDAL Update(TrainingExerciceDAL t);
        void Delete(TrainingExerciceDAL t);
    }
}
