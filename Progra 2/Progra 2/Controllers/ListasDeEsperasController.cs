using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeEsperasController : ControllerBase
    {
        private readonly IListaDeEspera _listaDeEsperaServicio;

        public ListaDeEsperasController(IListaDeEspera listaDeEsperaServicio)
        {
            _listaDeEsperaServicio = listaDeEsperaServicio;
        }

        // GET: api/<ListaDeEsperasController>
        [HttpGet]
        public IEnumerable<ListaDeEspera> Get()
        {
            var result = _listaDeEsperaServicio.GetAllListasDeEsperas();
            return result;
        }

        // GET api/<ListaDeEsperasController>/5
        [HttpGet("{id}")]
        public ListaDeEspera Get(int id)
        {
            var result = _listaDeEsperaServicio.GetListaDeEsperaById(id);
            return result;
        }

        // POST api/<ListaDeEsperasController>
        [HttpPost]
        public ListaDeEspera Post([FromBody] ListaDeEsperaDTOs dto)
        {
            var result = _listaDeEsperaServicio.CreateListaDeEspera(dto);
            return result;
        }

        [HttpPut("{id}/cancelar")]
        public ListaDeEspera Cancelar(int id)
        {
            return _listaDeEsperaServicio.CancelarEspera(id);
        }

        [HttpPut("atender")]
        public IActionResult AtenderSiguiente(int horarioId, DateTime fecha, int zonaId)
        {
            var resultado = _listaDeEsperaServicio.AtenderSiguienteEnLista(horarioId, fecha, zonaId);

            if (resultado == null)
                return NotFound("No hay entradas pendientes con esos parámetros");

            return Ok(resultado);
        }


    }
}
