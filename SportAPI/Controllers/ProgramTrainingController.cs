using BLL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProgramTrainingController : ControllerBase
    {
        private readonly IProgramTrainingRepositoryBLL _programTrainingRepositoryBLL;

        public ProgramTrainingController(IProgramTrainingRepositoryBLL programTrainingRepositoryBLL)
        {
            _programTrainingRepositoryBLL = programTrainingRepositoryBLL;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_programTrainingRepositoryBLL.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdProgram(int id)
        {
            return Ok(_programTrainingRepositoryBLL.GetByIdProgram(id));
        }

        [HttpGet("{id_program}/{id_training}")]
        public IActionResult GetById(int id_program, int id_training)
        {
            return Ok(_programTrainingRepositoryBLL.GetById(id_program, id_training));
        }

        [HttpPost]
        public IActionResult Create(ProgramTraining p)
        {
            try
            {
                _programTrainingRepositoryBLL.Create(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id_program}/{id_training}")]
        public IActionResult Delete(int id_program, int id_training)
        {
            try
            {
                ProgramTraining p = Mappers.ToAPI(_programTrainingRepositoryBLL.GetById(id_program, id_training));
                _programTrainingRepositoryBLL.Delete(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
