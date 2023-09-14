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
    public class TrainingServiceBLL : ITrainingRepositoryBLL<TrainingBLL>
    {
        private readonly ITrainingRepositoryDAL _trainingRepositoryDAL;

        public TrainingServiceBLL(ITrainingRepositoryDAL trainingRepositoryDAL)
        {
            _trainingRepositoryDAL = trainingRepositoryDAL;
        }

        public TrainingBLL Create(TrainingBLL t)
        {
            _trainingRepositoryDAL.Create(Mappers.ToDAL(t));
            return t;
        }

        public void Delete(TrainingBLL t)
        {
            _trainingRepositoryDAL.Delete(Mappers.ToDAL(t));
        }

        public IEnumerable<TrainingBLL> GetAll()
        {
            return _trainingRepositoryDAL.GetAll().Select(t => Mappers.ToBLL(t));
        }

        public TrainingBLL GetById(int id)
        {
            return Mappers.ToBLL(_trainingRepositoryDAL.GetById(id));
        }

        public void Update(TrainingBLL t)
        {
            _trainingRepositoryDAL.Update(Mappers.ToDAL(t));
        }

        public TrainingBLL GetLastTrainingCreated()
        {
            return Mappers.ToBLL(_trainingRepositoryDAL.GetLastTrainingCreated());
        }
    }
}
