using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IProgramRepositoryBLL<TEntity>
        where TEntity : new()
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllMyPrograms(int id_person);
        TEntity GetById(int id);
        TEntity Create(TEntity p, int id_person);
        void Update(TEntity p);
        void Delete(TEntity p);
        TEntity GetLastProgramCreated(int id);
    }
}
