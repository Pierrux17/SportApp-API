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
    public class TypePersonController : ControllerBase
    {
        private readonly ITypePersonRepositoryDAL _typePersonneRepository;

        public TypePersonController(ITypePersonRepositoryDAL typePersonneRepository)
        {
            _typePersonneRepository = typePersonneRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        { 
            return Ok(_typePersonneRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(TypePerson t)
        {
            try
            {
                _typePersonneRepository.Create(Mappers.ToDAL(t));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            return Ok(_typePersonneRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, TypePerson t)
        {
            try
            {
                _typePersonneRepository.Update(Mappers.ToDAL(t));
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
                TypePersonDAL t = _typePersonneRepository.GetById(id);
                _typePersonneRepository.Delete(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
