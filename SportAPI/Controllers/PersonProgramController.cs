using BLL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;
using System.Security.Claims;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonProgramController : ControllerBase
    {
        private readonly IPersonProgramRepositoryBLL _personProgramRepository;

        public PersonProgramController(IPersonProgramRepositoryBLL personProgramRepository)
        {
            _personProgramRepository = personProgramRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdPerson(int id)
        {
            // Obtenir le rôle et l'id de l'utilisateur connecté
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (currentUserRole != "Admin" && currentUserId != id)
            {
                // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
            }

            return Ok(_personProgramRepository.GetProgramsUsedByPerson(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_personProgramRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(PersonProgram p)
        {
            try
            {
                _personProgramRepository.Create(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        //GETBYID ET UPDATE PAS FORCEMENT IMPORTANT VU QUE C'EST UNE TABLE D'ASSOCIATION

        [HttpGet("{id_person}/{id_program}")]
        public IActionResult GetById(int id_person, int id_program)
        {
            return Ok(_personProgramRepository.GetById(id_person, id_program));
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, PersonProgram p)
        //{
        //    try
        //    {
        //        _personProgramRepositoryDAL.Update(Mappers.ToDAL(p));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //    return Ok("Tout s'est bien passé");
        //}

        [HttpDelete("{id_person}/{id_program}")]
        public IActionResult Delete(int id_person, int id_program)
        {
            try
            {
                PersonProgram p = Mappers.ToAPI(_personProgramRepository.GetById(id_person, id_program));
                _personProgramRepository.Delete(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
