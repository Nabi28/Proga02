using Entities;

namespace Services.Interfaces
{
    public interface ICliente
    {
        public List<Cliente> GetAllClientes();
        public Cliente GetClienteById(int clienteId);
        public Cliente CreateCliente(string nombre, string telefono, string correoElectronico);
        public Cliente UpdateCliente(int clienteId, Cliente cliente);
        public void DeleteCliente(int clienteId);
    }
}
