using BLL.Models;
using BLL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;
using System.Data;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciceLogController : ControllerBase
    {
        private readonly IExerciceLogRepositoryBLL<ExerciceLogBLL> _exerciceLogRepository;

        public ExerciceLogController(IExerciceLogRepositoryBLL<ExerciceLogBLL> exerciceLogRepository)
        {
            _exerciceLogRepository = exerciceLogRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            return Ok(_exerciceLogRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(ExerciceLog e)
        {
            try
            {
                _exerciceLogRepository.Create(Mappers.ToBLL(e));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_exerciceLogRepository.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ExerciceLog e)
        {
            try
            {
                _exerciceLogRepository.Update(Mappers.ToBLL(e));
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
                ExerciceLog e = Mappers.ToAPI(_exerciceLogRepository.GetById(id));
                _exerciceLogRepository.Delete(Mappers.ToBLL(e));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdTrainingLog(int id)
        {
            return Ok(_exerciceLogRepository.GetByIdTrainingLog(id));
        }
    }
}
