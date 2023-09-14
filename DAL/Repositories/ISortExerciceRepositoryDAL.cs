using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISortExerciceRepositoryDAL
    {
        SortExerciceDAL Create(SortExerciceDAL s);
        IEnumerable<SortExerciceDAL> GetAll();
        SortExerciceDAL GetById(int id);
        SortExerciceDAL Update(SortExerciceDAL s);
        void Delete(SortExerciceDAL s);
    }
}
