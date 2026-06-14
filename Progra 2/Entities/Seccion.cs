namespace Entities
{
    public class Seccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //relationships
        public ICollection<Zona> Zonas { get; set; }
    }
}
