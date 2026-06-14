using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly IZona _zonasService;
        public ZonasController(IZona zonasService)
        {
            _zonasService = zonasService;
        }
        // GET: api/<ZonasController>
        [HttpGet]
        public IEnumerable<Zona> Get()
        {
            var result = _zonasService.GetAllZonas();
            return result;
        }

        // GET api/<ZonasController>/5
        [HttpGet("{id}")]
        public Zona Get(int id)
        {
            var result = _zonasService.GetZonaById(id);
            return result;
        }

        // POST api/<ZonasController>
        [HttpPost]
        public Zona Post([FromBody] Zona newZona)
        {
            var result = _zonasService.CreateZona(
                newZona.Nombre,
                newZona.SeccionId);
            return result;
        }

        // PUT api/<ZonasController>/5
        [HttpPut("{id}")]
        public Zona Put(int id, [FromBody] Zona updateZona)
        {
            var result = _zonasService.UpdateZona(id, updateZona);
            return result;
        }

        // DELETE api/<ZonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _zonasService.DeleteZona(id);
        }
    }
}
