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
    public class TypeExerciceController : ControllerBase
    {
        private readonly ITypeExerciceRepositoryDAL _typeExerciceRepository;

        public TypeExerciceController(ITypeExerciceRepositoryDAL typeExerciceRepository)
        {
            _typeExerciceRepository = typeExerciceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_typeExerciceRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(TypeExercice t)
        {
            try
            {
                _typeExerciceRepository.Create(Mappers.ToDAL(t));
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
            return Ok(_typeExerciceRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, TypeExercice t)
        {
            try
            {
                _typeExerciceRepository.Update(Mappers.ToDAL(t));
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
                TypeExerciceDAL t = _typeExerciceRepository.GetById(id);
                _typeExerciceRepository.Delete(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
