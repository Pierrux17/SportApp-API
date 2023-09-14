using BLL.Models;
using BLL.Repositories;
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
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceRepositoryBLL<PerformanceBLL> _performanceRepository;

        public PerformanceController(IPerformanceRepositoryBLL<PerformanceBLL> performanceRepository)
        {
            this._performanceRepository = performanceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_performanceRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Performance p)
        {
            try
            {
                _performanceRepository.Create(Mappers.ToBLL(p));
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
            return Ok(_performanceRepository.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Performance p)
        {
            try
            {
                _performanceRepository.Update(Mappers.ToBLL(p));
                
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
                Performance p = Mappers.ToAPI(_performanceRepository.GetById(id));
                _performanceRepository.Delete(Mappers.ToBLL(p));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Tout s'est bien passé");
        }
    }
}
