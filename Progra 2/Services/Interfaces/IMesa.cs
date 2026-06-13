using DTOs;
using Entities;

namespace Services.Interfaces
{
    public interface IMesa
    {
        // reads
        public List<Mesa> GetAllMesas();
        public Mesa GetMesaById(int id);
        // writes
        public Mesa CreateMesa(Mesa mesa);
        public Mesa UpdateMesa(int id, Mesa mesa);
        void DeleteMesa(int id);
        public Mesa CambiarEstadoMesa(int mesaId, string estado);
    }
}
