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
    public class TrainingExerciceController : ControllerBase
    {
        private readonly ITrainingExerciceRepositoryBLL _trainingExerciceRepositoryBLL;

        public TrainingExerciceController(ITrainingExerciceRepositoryBLL trainingExerciceRepositoryBLL)
        {
            _trainingExerciceRepositoryBLL = trainingExerciceRepositoryBLL;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_trainingExerciceRepositoryBLL.GetAll().OrderBy(t => t.Cpt));
        }

        [HttpPost]
        public IActionResult Create(TrainingExercice t)
        {
            try
            {
                _trainingExerciceRepositoryBLL.Create(Mappers.ToBLL(t));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdTraining(int id)
        {
            return Ok(_trainingExerciceRepositoryBLL.GetByIdTraining(id));
        }

        [HttpGet("{id_training}/{id_exercice}")]
        public IActionResult GetById(int id_training, int id_exercice)
        {
            return Ok(_trainingExerciceRepositoryBLL.GetById(id_training, id_exercice));
        }


        [HttpPut("{id_training}/{id_exercice}")]
        public IActionResult Update(TrainingExercice t)
        {
            _trainingExerciceRepositoryBLL.Update(Mappers.ToBLL(t));
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id_training}/{id_exercice}")]
        public IActionResult Delete(int id_training, int id_exercice)
        {
            try
            {
                TrainingExercice t = Mappers.ToAPI(_trainingExerciceRepositoryBLL.GetById(id_training, id_exercice));
                _trainingExerciceRepositoryBLL.Delete(Mappers.ToBLL(t));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
