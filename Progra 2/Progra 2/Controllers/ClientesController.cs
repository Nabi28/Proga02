using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _clienteService;
        public ClientesController(ICliente clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            var result = _clienteService.GetAllClientes();
            return result;
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var result = _clienteService.GetClienteById(id);
            return result;
        }

        // POST api/<ClientesController>     }nota, ya hereda la ruta base api/clientes
        [HttpPost]
        public Cliente Post([FromBody] Cliente newCliente)
        {
            var result = _clienteService.CreateCliente(
                newCliente.Nombre,
                newCliente.Telefono,
                newCliente.CorreoElectronico);
            return result;
        }

        // PUT api/<ClientesController>/5    }nota, ya hereda la ruta base api/clientes + id
        [HttpPut("{id}")]
        public Cliente Put(int id, [FromBody] Cliente updateCliente)
        {
            var result = _clienteService.UpdateCliente(id, updateCliente);
            return result;
        }

        // DELETE api/<ClientesController>/5  }nota, ya hereda la ruta base api/clientes + id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clienteService.DeleteCliente(id);
        }
    }
}
