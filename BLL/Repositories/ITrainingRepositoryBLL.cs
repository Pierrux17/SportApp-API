using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface ITrainingRepositoryBLL<TEntity>
        where TEntity : new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity t);
        void Update(TEntity t);
        void Delete(TEntity t);
        TEntity GetLastTrainingCreated();
    }
}
