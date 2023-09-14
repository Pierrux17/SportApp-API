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
    public class TypeProgramController : ControllerBase
    {
        private readonly ITypeProgramRepositoryDAL _typeProgramRepository;

        public TypeProgramController(ITypeProgramRepositoryDAL typeProgramRepository)
        {
            _typeProgramRepository = typeProgramRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_typeProgramRepository.GetAll());
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(TypeProgram t)
        {
            try
            {
                _typeProgramRepository.Create(Mappers.ToDAL(t));
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
            return Ok(_typeProgramRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, TypeProgram t)
        {
            try
            {
                _typeProgramRepository.Update(Mappers.ToDAL(t));
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
                TypeProgramDAL t = _typeProgramRepository.GetById(id);
                _typeProgramRepository.Delete(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
