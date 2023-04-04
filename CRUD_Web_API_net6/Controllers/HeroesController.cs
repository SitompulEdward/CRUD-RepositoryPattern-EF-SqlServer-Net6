using CRUD_Web_API_net6.Service.HeroesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CRUD_Web_API_net6.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHerosService _service;
        private readonly DataContext _context;
        public HeroesController(IHerosService service, DataContext dataContext)
        {
            _service = service;
            _context = dataContext;
        }

        [HttpGet]
        [Route("GetAllHeroes")]
        public async Task<ActionResult<List<Heroes>>> GetAll()
        {
            return Ok(await _service.GetAllHeroes());
        }
        
        [HttpGet]
        [Route("GetHeroesDetail/{id}")]
        public async Task<ActionResult<Heroes>> GetDetail(int id)
        {
            var data = await _service.GetDetailHeroes(id);

            if (data == null)
            {
                return BadRequest("Heroes Not Found");
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("AddHeroes")]
        public async Task<ActionResult<List<Heroes>>> AddHeroes(Heroes request)
        {
            var data = await _service.AddHeroes(request);
            
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateHeroes/{id}")]
        public async Task<ActionResult<Heroes>> UpdateHeroes(int id, Heroes request)
        {
            var data = await _service.UpdateHeroes(id,request);

            if (data == null)
            {
                return BadRequest("Heroes Not Found");
            }

            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteHeroes/{id}")]
        public async Task<ActionResult<List<Heroes>>> DeleteHeroes(int id)
        {
            var data = await _service.DeleteHeroes(id);

            if (data == null)
            {
                return BadRequest("Heroes Not Found");
            }

            return Ok(data);
        }

    }
}
