using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IProfilRepositoryBLL<TEntity>
        where TEntity : new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity p);
        void Update(TEntity p);

        TEntity GetByIdPerson(int id);
    }
}
