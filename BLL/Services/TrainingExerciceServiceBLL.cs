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
    public class TrainingExerciceServiceBLL : ITrainingExerciceRepositoryBLL
    {
        private readonly ITrainingExerciceRepositoryDAL _trainingExerciceRepositoryDAL;
        private readonly ITrainingRepositoryDAL _trainingRepositoryDAL;
        private readonly IExerciceRepositoryDAL _exerciceRepositoryDAL;

        public TrainingExerciceServiceBLL(ITrainingExerciceRepositoryDAL trainingExerciceRepositoryDAL, ITrainingRepositoryDAL trainingRepositoryDAL, IExerciceRepositoryDAL exerciceRepositoryDAL)
        {
            _trainingExerciceRepositoryDAL = trainingExerciceRepositoryDAL;
            _trainingRepositoryDAL = trainingRepositoryDAL;
            _exerciceRepositoryDAL = exerciceRepositoryDAL;
        }

        public TrainingExerciceBLL Create(TrainingExerciceBLL t)
        {
            _trainingExerciceRepositoryDAL.Create(Mappers.ToDAL(t));
            return t;
        }

        public void Delete(TrainingExerciceBLL t)
        {
            _trainingExerciceRepositoryDAL.Delete(Mappers.ToDAL(t));
        }

        public IEnumerable<TrainingExerciceBLL> GetAll()
        {
            return _trainingExerciceRepositoryDAL.GetAll().Select(t => Mappers.ToBLL(t));
        }

        public TrainingExerciceBLL GetById(int id_training, int id_exercice)
        {
            return Mappers.ToBLL(_trainingExerciceRepositoryDAL.GetById(id_training, id_exercice));
        }

        public IEnumerable<TrainingExerciceBLL> GetByIdTraining(int id)
        {
            TrainingBLL training = Mappers.ToBLL(_trainingRepositoryDAL.GetById(id));
            IEnumerable<TrainingExerciceBLL> list = _trainingExerciceRepositoryDAL.GetAll().Where(t => t.Id_training == training.Id).Select(x => Mappers.ToBLL(x));
            return list;
        }

        public void Update(TrainingExerciceBLL t)
        {
            _trainingExerciceRepositoryDAL.Update(Mappers.ToDAL(t));
        }
    }
}
