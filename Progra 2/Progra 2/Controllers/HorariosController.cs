using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly IHorario _horarioService;
        public HorariosController(IHorario horarioService)
        {
            _horarioService = horarioService;
        }
        // GET: api/<HorariosController>
        [HttpGet]
        public IEnumerable<Horario> Get()
        {
            var result = _horarioService.GetAllHorario();
            return result;
        }

        // GET api/<HorariosController>/5
        [HttpGet("{id}")]
        public Horario Get(int id)
        {
            var result = _horarioService.GetHorarioById(id);
            return result;
        }

        [HttpGet("validar")]
        public string ValidarHorario(DateTime fecha, int horarioId)
        {
            var result = _horarioService.ValidarHorario(fecha, horarioId);
            return result;
        }

    }
}

