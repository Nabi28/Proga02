using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloqueosController : ControllerBase
    {
        private readonly IBloqueo _bloqueoService;
        public BloqueosController(IBloqueo bloqueoService)
        {
            _bloqueoService = bloqueoService;
        }
        // GET: api/<BloqueosController>
        [HttpGet]
        public IEnumerable<Bloqueo> Get()
        {
            var result = _bloqueoService.GetAllBloqueos();
            return result;
        }

        // GET api/<BloqueosController>/5
        [HttpGet("{id}")]
        public Bloqueo Get(int id)
        {
            var result = _bloqueoService.GetBloqueoById(id);
            return result;
        }

        //Get api/<BloqueosController>/verificar
        [HttpGet("verificar")]
        public bool VerificarBloqueo(int mesaId, DateTime fechaHora)
        {
            return _bloqueoService.VerificarBloqueo(mesaId, fechaHora);
        }


        // POST api/<BloqueosController>/mesa
        [HttpPost("mesa")]
        public Bloqueo PostMesa([FromBody] BloqueoMesaDTOs dto)
        {
            var result = _bloqueoService.CreateBloqueoMesa(dto);
            return result;
        }

        // POST api/<BloqueosController>/zona
        [HttpPost("zona")]
        public Bloqueo PostZona([FromBody] BloqueoZonaDTOs dto)
        {
            var result = _bloqueoService.CreateBloqueoZona(dto);
            return result;
        }

        [HttpDelete("{id}")]
        public Bloqueo Delete(int id)
        {
            return _bloqueoService.DeleteBloqueo(id);
        }


    }
}
