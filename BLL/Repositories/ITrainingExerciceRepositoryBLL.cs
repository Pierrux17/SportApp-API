using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface ITrainingExerciceRepositoryBLL
    {
        IEnumerable<TrainingExerciceBLL> GetByIdTraining(int id);
        TrainingExerciceBLL Create(TrainingExerciceBLL t);

        IEnumerable<TrainingExerciceBLL> GetAll();
        TrainingExerciceBLL GetById(int id_training, int id_exercice);
        void Update(TrainingExerciceBLL t);
        void Delete(TrainingExerciceBLL t);
    }
}
