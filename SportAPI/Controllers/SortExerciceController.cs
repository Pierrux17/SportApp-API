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
    public class SortExerciceController : ControllerBase
    {
        private readonly ISortExerciceRepositoryDAL _sortExerciceRepository;

        public SortExerciceController(ISortExerciceRepositoryDAL sortExerciceRepository)
        {
            _sortExerciceRepository = sortExerciceRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_sortExerciceRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(SortExercice s)
        {
            try
            {
                _sortExerciceRepository.Create(Mappers.ToDAL(s));
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
            return Ok(_sortExerciceRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, SortExercice s)
        {
            try
            {
                _sortExerciceRepository.Update(Mappers.ToDAL(s));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                SortExerciceDAL s = _sortExerciceRepository.GetById(id);
                _sortExerciceRepository.Delete(s);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
