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
    public class ExerciceLogServiceBLL : IExerciceLogRepositoryBLL<ExerciceLogBLL>
    {
        private readonly IExerciceLogRepositoryDAL _exerciceLogRepository;
        private readonly ITrainingLogRepositoryDAL _trainingLogRepository;

        public ExerciceLogServiceBLL(IExerciceLogRepositoryDAL exerciceLogRepository, ITrainingLogRepositoryDAL trainingLogRepository)
        {
            _exerciceLogRepository = exerciceLogRepository;
            _trainingLogRepository = trainingLogRepository;
        }

        public ExerciceLogBLL Create(ExerciceLogBLL e)
        {
            _exerciceLogRepository.Create(Mappers.ToDAL(e));
            return e;
        }

        public void Delete(ExerciceLogBLL p)
        {
            _exerciceLogRepository.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<ExerciceLogBLL> GetAll()
        {
            return _exerciceLogRepository.GetAll().Select(e => Mappers.ToBLL(e));
        }

        public ExerciceLogBLL GetById(int id)
        {
            return Mappers.ToBLL(_exerciceLogRepository.GetById(id));
        }

        public IEnumerable<ExerciceLogBLL> GetByIdTrainingLog(int id)
        {
            TrainingLogBLL t = Mappers.ToBLL(_trainingLogRepository.GetById(id));
            IEnumerable<ExerciceLogBLL> listE = _exerciceLogRepository.GetAll().Where(e => e.Id_training_log == t.Id).Select(e => Mappers.ToBLL(e));
            return listE;
        }

        public void Update(ExerciceLogBLL e)
        {
            _exerciceLogRepository.Update(Mappers.ToDAL(e));
        }
    }
}
