using BLL.Repositories;
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
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepositoryDAL _trainingRepository;

        public TrainingController(ITrainingRepositoryDAL trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_trainingRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Training t)
        {
            try
            {
                _trainingRepository.Create(Mappers.ToDAL(t));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_trainingRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Training t)
        {
            try
            {
                _trainingRepository.Update(Mappers.ToDAL(t));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TrainingDAL t = _trainingRepository.GetById(id);
                _trainingRepository.Delete(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("GetLastTrainingCreated")]
        public IActionResult GetLastTrainingCreated()
        {
            try
            {
                var lastCreatedTraining = _trainingRepository.GetLastTrainingCreated();
                if (lastCreatedTraining == null)
                {
                    return NotFound();
                }

                return Ok(lastCreatedTraining);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération du dernier training créé.");
            }
        }
    }
}
