using DTOs;
using Entities;
namespace Services.Interfaces;


public interface IListaDeEspera
{
    // reads
    public List<ListaDeEspera> GetAllListasDeEsperas();
    public ListaDeEspera GetListaDeEsperaById(int id);
    // writes
    public ListaDeEspera CreateListaDeEspera(ListaDeEsperaDTOs dto);
    public ListaDeEspera AtenderSiguienteEnLista(int horario, DateTime fecha, int zonaId);
    public ListaDeEspera CancelarEspera(int listaDeEsperaId);
}
