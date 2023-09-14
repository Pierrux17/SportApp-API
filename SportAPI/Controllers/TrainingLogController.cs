using BLL.Models;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;
using System.Data;
using System.Security.Claims;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingLogController : ControllerBase
    {
        private readonly ITrainingLogRepositoryBLL<TrainingLogBLL> _trainingLogRepository;

        public TrainingLogController(ITrainingLogRepositoryBLL<TrainingLogBLL> trainingLogRepository)
        {
            _trainingLogRepository = trainingLogRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            return Ok(_trainingLogRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(TrainingLog t)
        {
            try
            {
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la creation 
                if (currentUserRole != "Admin" && currentUserId != t.Id_person)
                {
                    // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
                }
                _trainingLogRepository.Create(Mappers.ToBLL(t));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TrainingLog t = Mappers.ToAPI(_trainingLogRepository.GetById(id));

            // Obtenir le rôle et l'id de l'utilisateur connecté
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (currentUserRole != "Admin" && currentUserId != t.Id_person)
            {
                // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
            }

            return Ok(t);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TrainingLog t)
        {
            try
            {
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la creation 
                if (currentUserRole != "Admin" && currentUserId != t.Id_person)
                {
                    // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
                }
                _trainingLogRepository.Update(Mappers.ToBLL(t));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TrainingLog t = Mappers.ToAPI(_trainingLogRepository.GetById(id));

                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la creation 
                if (currentUserRole != "Admin" && currentUserId != t.Id_person)
                {
                    // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
                }

                _trainingLogRepository.Delete(Mappers.ToBLL(t));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("person/{id_person}")]
        public IActionResult GetByIdPerson(int id_person)
        {
            // Obtenir le rôle et l'id de l'utilisateur connecté
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (currentUserRole != "Admin" && currentUserId != id_person)
            {
                // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
            }

            return Ok(_trainingLogRepository.GetByIdPerson(id_person));
        }
    }
}
