using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IExerciceLogRepositoryDAL
    {
        ExerciceLogDAL Create(ExerciceLogDAL e);
        IEnumerable<ExerciceLogDAL> GetAll();
        ExerciceLogDAL GetById(int id);
        ExerciceLogDAL Update(ExerciceLogDAL e);
        void Delete(ExerciceLogDAL e);
    }
}
