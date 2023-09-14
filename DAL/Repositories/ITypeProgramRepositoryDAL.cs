using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ITypeProgramRepositoryDAL
    {
        TypeProgramDAL Create(TypeProgramDAL t);
        IEnumerable<TypeProgramDAL> GetAll();
        TypeProgramDAL GetById(int id);
        TypeProgramDAL Update(TypeProgramDAL t);
        void Delete(TypeProgramDAL t);
    }
}
