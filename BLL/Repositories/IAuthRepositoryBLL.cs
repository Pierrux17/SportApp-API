using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public interface IAuthRepositoryBLL
    {
        Task<string> GenerateJwtToken(LoginBLL user);
    }
}
