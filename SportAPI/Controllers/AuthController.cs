using BLL.Models;
using BLL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Models;
using SportAPI.Tools;

namespace SportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepositoryBLL _authRepositoryBLL;
        private readonly IPersonRepositoryBLL<PersonBLL> _personRepositoryBLL;

        public AuthController(IAuthRepositoryBLL authRepositoryBLL, IPersonRepositoryBLL<PersonBLL> personRepositoryBLL)
        {
            _authRepositoryBLL = authRepositoryBLL;
            _personRepositoryBLL = personRepositoryBLL;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginForm login)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            //Person connectedP;

            try
            {
               // connectedP = Mappers.ToAPI(_personRepositoryBLL.Login(Mappers.ToBLL(login)));

                var token = await _authRepositoryBLL.GenerateJwtToken(Mappers.ToBLL(login));
                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(new { token });
                //connectedP.Token = token;
                //return Ok(connectedP);
            }
            catch (ArgumentException e)
            {
                return Unauthorized(new { message = e.Message });
            }
        }

        [HttpPost("register")]
        public IActionResult Register(Person p)
        {
            try
            {
                _personRepositoryBLL.Create(Mappers.ToBll(p));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
