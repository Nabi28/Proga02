using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Progra_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionesController : ControllerBase
    {
        private readonly ISeccion _seccionService;
        public SeccionesController(ISeccion seccionService)
        {
            _seccionService = seccionService;
        }
        // GET: api/<SeccionesController>
        [HttpGet]
        public IEnumerable<Seccion> Get()
        {
            var result = _seccionService.GetAllSecciones();
            return result;
        }

        // GET api/<SeccionesController>/5
        [HttpGet("{id}")]
        public Seccion Get(int id)
        {
            var result = _seccionService.GetSeccionById(id);
            return result;
        }

        // POST api/<SeccionesController>
        [HttpPost]
        public Seccion Post([FromBody] Seccion newSeccion)
        {
            var result = _seccionService.CreateSeccion(newSeccion);
            return result;
        }


    }
}
