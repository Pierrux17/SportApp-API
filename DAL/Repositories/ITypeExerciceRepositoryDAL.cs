using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ITypeExerciceRepositoryDAL
    {
        TypeExerciceDAL Create(TypeExerciceDAL t);
        IEnumerable<TypeExerciceDAL> GetAll();
        TypeExerciceDAL GetById(int id);
        TypeExerciceDAL Update(TypeExerciceDAL t);
        void Delete(TypeExerciceDAL t);

    }
}
