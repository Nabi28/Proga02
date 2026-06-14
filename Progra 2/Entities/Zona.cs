
namespace Entities
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int SeccionId { get; set; }

        //realtionships
        public ICollection<Mesa> Mesas { get; set; }
        public ICollection<Bloqueo> Bloqueos { get; set; }
        public ICollection<ListaDeEspera> ListasDeEsperas { get; set; }

        //propiedad de navegación

        public Seccion Seccion { get; set; }

    }
}
