
namespace Entities
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int SeccionId { get; set; }

        //realtionships
        public ICollection<Bloqueo> Bloqueos { get; set; }
    }
}
