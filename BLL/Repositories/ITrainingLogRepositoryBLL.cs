using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface ITrainingLogRepositoryBLL<TEntity>
        where TEntity : new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity e);
        void Update(TEntity e);
        void Delete(TEntity p);
        IEnumerable<TEntity> GetByIdPerson(int id);
    }
}
