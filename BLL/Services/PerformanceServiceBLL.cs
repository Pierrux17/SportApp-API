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
    public class PerformanceServiceBLL : IPerformanceRepositoryBLL<PerformanceBLL>
    {
        private readonly IPerformanceRepositoryDAL _performanceRepository;

        public PerformanceServiceBLL(IPerformanceRepositoryDAL performanceRepository)
        {
            _performanceRepository = performanceRepository;
        }

        public PerformanceBLL Create(PerformanceBLL p)
        {
            p.Date = DateTime.Now;

            _performanceRepository.Create(Mappers.ToDAL(p));
            return p;
        }

        public void Delete(PerformanceBLL p)
        {
            _performanceRepository.Delete(Mappers.ToDAL(p));
        }

        public IEnumerable<PerformanceBLL> GetAll()
        {
            return _performanceRepository.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public PerformanceBLL GetById(int id)
        {
            return Mappers.ToBLL(_performanceRepository.GetById(id));
        }

        public void Update(PerformanceBLL p)
        {
            p.Date = DateTime.Now;
            _performanceRepository.Update(Mappers.ToDAL(p));
        }
    }
}
