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
    public class TrainingLogServiceBLL : ITrainingLogRepositoryBLL<TrainingLogBLL>
    {
        private readonly ITrainingLogRepositoryDAL _trainingLogRepository;
        private readonly IPersonRepositoryDAL _personRepository;

        public TrainingLogServiceBLL(ITrainingLogRepositoryDAL trainingLogRepository, IPersonRepositoryDAL personRepository)
        {
            _trainingLogRepository = trainingLogRepository;
            _personRepository = personRepository;
        }

        public TrainingLogBLL Create(TrainingLogBLL t)
        {
            t.Date = DateTime.Now;
            _trainingLogRepository.Create(Mappers.ToDAL(t));
            return t;
        }

        public void Delete(TrainingLogBLL p)
        {
            _trainingLogRepository.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<TrainingLogBLL> GetAll()
        {
            return _trainingLogRepository.GetAll().Select(t => Mappers.ToBLL(t));
        }

        public TrainingLogBLL GetById(int id)
        {
            return Mappers.ToBLL(_trainingLogRepository.GetById(id));
        }

        public IEnumerable<TrainingLogBLL> GetByIdPerson(int id)
        {
            PersonBLL p = Mappers.ToBLL(_personRepository.GetById(id));
            IEnumerable<TrainingLogBLL> listT = _trainingLogRepository.GetAll().Where(t => t.Id_person == p.Id).Select(t => Mappers.ToBLL(t));
            return listT;
        }

        public void Update(TrainingLogBLL t)
        {
            _trainingLogRepository.Update(Mappers.ToDAL(t));
        }
    }
}
