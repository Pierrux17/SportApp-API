using DAL.Entities;
using DAL.Repositories;
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
    public class ExerciceController : ControllerBase
    {
        private readonly IExerciceRepositoryDAL _exerciceRepository;

        public ExerciceController(IExerciceRepositoryDAL exerciceRepository)
        {
            _exerciceRepository = exerciceRepository;
        }

        [HttpGet]
        public ActionResult GetAll() 
        {
            return Ok(_exerciceRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Exercice e)
        {
            try
            {
                _exerciceRepository.Create(Mappers.ToDAL(e));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_exerciceRepository.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Exercice e)
        {
            try
            {
                _exerciceRepository.Update(Mappers.ToDAL(e));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                ExerciceDAL e = _exerciceRepository.GetById(id);
                _exerciceRepository.Delete(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
