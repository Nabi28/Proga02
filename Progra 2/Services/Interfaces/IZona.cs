using Entities;

namespace Services.Interfaces
{
    public interface IZona
    {
        public List<Zona> GetAllZonas();
        public Zona GetZonaById(int id);
        public Zona CreateZona(string nombre, int seccionId);
        public Zona UpdateZona(int zonaId, Zona zona);
        public void DeleteZona(int zonaId);

    }
}
