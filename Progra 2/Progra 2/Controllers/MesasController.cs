using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesa _mesaServicio;

        public MesasController(IMesa mesaServicio)
        {
            _mesaServicio = mesaServicio;
        }

        // GET: api/<MesaController>
        [HttpGet]
        public IEnumerable<Mesa> Get()
        {
            var result = _mesaServicio.GetAllMesas();
            return result;
        }

        // GET api/<MesaController>/5
        [HttpGet("{id}")]
        public Mesa Get(int id)
        {
            var result = _mesaServicio.GetMesaById(id);
            return result;
        }

        // POST api/<MesaController>
        [HttpPost]
        public Mesa Post([FromBody] Mesa newMesa)
        {
            var result = _mesaServicio.CreateMesa(newMesa);
            return result;
        }

        // PUT api/<MesaController>/5

        [HttpPut("{id}")]
        public Mesa Put(int id, [FromBody] Mesa updatedMesa)
        {
            var result = _mesaServicio.UpdateMesa(id, updatedMesa);
            return result;
        }

        // DELETE api/<MesaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mesaServicio.DeleteMesa(id);
        }

        [HttpPut("{mesaId}/estado")]
        public Mesa CambiarEstado(int mesaId, string estado)
        {
            return _mesaServicio.CambiarEstadoMesa(mesaId, estado);
        }
    }
}
