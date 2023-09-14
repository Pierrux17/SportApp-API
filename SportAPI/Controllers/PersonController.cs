using BLL.Models;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepositoryBLL<PersonBLL> _personRepository;
        private readonly IAuthRepositoryBLL _authRepositoryBLL;

        public PersonController(IPersonRepositoryBLL<PersonBLL> personRepository, IAuthRepositoryBLL authRepositoryBLL)
        {
            _personRepository = personRepository;
            _authRepositoryBLL = authRepositoryBLL;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Person p)
        {
            try
            {
                _personRepository.Create(Mappers.ToBll(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Obtenir le rôle et l'id de l'utilisateur connecté
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            PersonBLL p = _personRepository.GetById(id);

            // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la suppression de tous les profils
            if (currentUserRole != "Admin" && currentUserId != p.Id)
            {
                // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
            }
            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person p)
        {
            try
            {
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la modification de tous les profils
                if (currentUserRole != "Admin" && currentUserId != p.Id)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à modifier cet utilisateur.");
                }

                _personRepository.Update(Mappers.ToBll(p));
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
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                PersonBLL p = _personRepository.GetById(id);

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la suppression de tous les profils
                if (currentUserRole != "Admin" && currentUserId != p.Id)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à supprimer cet utilisateur.");
                }
                _personRepository.Delete(p);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Person connectedP;

            try
            {
                connectedP = connectedP = Mappers.ToAPI(_personRepository.Login(Mappers.ToBLL(form)));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            //connectedP = _token.GenerateJWT(connectedP);

            return Ok(connectedP);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Person p)
        {
            try
            {
                _personRepository.Create(Mappers.ToBll(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
