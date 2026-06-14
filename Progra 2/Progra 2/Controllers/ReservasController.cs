using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReserva _reservaService;
        public ReservasController(IReserva reservaService)
        {
            _reservaService = reservaService;
        }
        // GET: api/<ReservasController>
        [HttpGet]
        public IEnumerable<Reserva> Get()
        {
            var result = _reservaService.GetAllReservas();
            return result;
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public Reserva Get(int id)
        {
            var result = _reservaService.GetReservaById(id);
            return result;
        }

        // POST api/<ReservasController>
        [HttpPost]
        public Reserva Post([FromBody] CreateReservaDTOs dto)
        {
            var result = _reservaService.CreateReserva(dto);
            return result;

        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}/atender")]
        public Reserva Put(int id)
        {
            var result = _reservaService.AtenderReserva(id);
            return result;
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}/cancelar")]
        public void Delete(int id)
        {
            _reservaService.CancelarReserva(id);
        }

        [HttpGet("verificar")]
        public IActionResult VerificarDisponibilidad(int mesaId, int horarioId, DateTime fecha)
        {
            var disponibilidad = _reservaService.ValidarDisponibilidadMesa(mesaId, horarioId, fecha);
            if (disponibilidad)
            {
                return Ok("La mesa está disponible.");
            }
            else
            {
                return BadRequest("La mesa no está disponible en la fecha y hora seleccionadas.");
            }
        }
    }
}

