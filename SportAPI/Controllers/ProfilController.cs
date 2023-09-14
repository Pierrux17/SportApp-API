using BLL.Models;
using BLL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;
using System;
using System.Data;
using System.Security.Claims;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly IProfilRepositoryBLL<ProfilBLL> _profilRepository;

        public ProfilController(IProfilRepositoryBLL<ProfilBLL> profilRepository)
        {
            _profilRepository = profilRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Ok(_profilRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Profil p)
        {
            try
            {
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la suppression de tous les profils
                if (currentUserRole != "Admin" && currentUserId != p.Id_person)
                {
                    // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
                }
                _profilRepository.Create(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("{id}", Name = "GetProfilById")]
        public IActionResult GetById(int id)
        {
            // Obtenir le rôle et l'id de l'utilisateur connecté
            string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Profil p = Mappers.ToAPI(_profilRepository.GetById(id));

            // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la suppression de tous les profils
            if (currentUserRole != "Admin" && currentUserId != p.Id_person)
            {
                // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
            }
            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Profil p)
        {
            try
            {
                // Obtenir le rôle et l'id de l'utilisateur connecté
                string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
                int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la modification de tous les profils
                if (currentUserRole != "Admin" && currentUserId != p.Id_person)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à modifier ce profil.");
                }

                _profilRepository.Update(Mappers.ToBLL(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }

        [HttpGet("person/{id_person}", Name = "GetProfilByPersonId")]
        public IActionResult GetByIdPerson(int id_person)
        {
            // Obtenir le rôle et l'id de l'utilisateur connecté
            //string currentUserRole = User.FindFirstValue(ClaimTypes.Role);
            //int currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                Profil p = Mappers.ToAPI(_profilRepository.GetByIdPerson(id_person));

                // Vérifier si l'utilisateur actuel a le rôle "Admin" pour autoriser la suppression de tous les profils
                //if (currentUserRole != "Admin" && currentUserId != p.Id_person)
                //{
                //    // Si il n'est pas admin, l'utilisateur ne peut que se sélectionner lui-même
                //    return StatusCode(StatusCodes.Status403Forbidden, "Vous n'êtes pas autorisé à faire ceci.");
                //}
                return Ok(p);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
        }

        //!!!!!!!!!!!!!!!!!!!!! Le profil doit se delete lorsqu'un utilisateur est supprimé
    }
}
