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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CountryController : ControllerBase
    {
        private readonly ICountryRepositoryDAL _countryRepository;

        public CountryController(ICountryRepositoryDAL countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_countryRepository.GetAll());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Country c)
        {
            try
            {
                _countryRepository.Create(Mappers.ToDAL(c));
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
            return Ok(_countryRepository.GetById(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody] Country c)
        {
            try
            {
               Country newC = Mappers.ToAPI(_countryRepository.Update(Mappers.ToDAL(c)));
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
                Country c = Mappers.ToAPI(_countryRepository.GetById(id));
                _countryRepository.Delete(Mappers.ToDAL(c));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
