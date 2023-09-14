using BLL.Models;
using BLL.Repositories;
using DAL.Repositories;
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
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepositoryBLL<ProgramBLL> _programRepositoryBLL;

        public ProgramController(IProgramRepositoryBLL<ProgramBLL> programRepositoryBLL)
        {
            _programRepositoryBLL = programRepositoryBLL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (currentUserRole == "Admin")
            {
                // L'utilisateur est un administrateur, appeler GetAll directement
                return Ok(_programRepositoryBLL.GetAll());
            }
            else
            {
                // L'utilisateur est un utilisateur standard, appeler GetAllMyPrograms
                return Ok(_programRepositoryBLL.GetAllMyPrograms(currentUserId));
            }
        }

        [HttpPost]
        public IActionResult Create(Models.Program p)
        {
            try
            {
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (currentUserRole != "Admin"){
                    p.Is_my_Program = true;
                }
                _programRepositoryBLL.Create(Mappers.ToBLL(p), currentUserId);
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
            return Ok(_programRepositoryBLL.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.Program p)
        {
            try
            {
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Si le user n'est admin, il doit avoir créé le program pour pouvoir le modifier
                if (currentUserRole != "Admin" && p.Created_by == currentUserId)
                {
                    _programRepositoryBLL.Update(Mappers.ToBLL(p));
                }

                // Si il est admin, il peut tout modifier
                if(currentUserRole == "Admin")
                {
                    _programRepositoryBLL.Update(Mappers.ToBLL(p));
                }
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
                ProgramBLL p = _programRepositoryBLL.GetById(id);

                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Si le user n'est admin, il doit avoir créé le program pour pouvoir le supprimer
                if (currentUserRole != "Admin" && p.Created_by == currentUserId)
                {
                    _programRepositoryBLL.Delete(p);
                }

                // Si il est admin, il peut tout supprimer
                if (currentUserRole == "Admin")
                {
                    _programRepositoryBLL.Delete(p);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("GetLastProgramCreated")]
        public IActionResult GetLastProgramCreated()
        {
            try
            {
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var lastCreatedProgram = _programRepositoryBLL.GetLastProgramCreated(currentUserId);
                if (lastCreatedProgram == null)
                {
                    return NotFound();
                }

                return Ok(lastCreatedProgram);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erreur lors de la récupération du dernier programme créé.");
            }
        }

    }
}
