using Entities;
using Services.Interfaces;
using DATA;

namespace Services
{
    public class ClienteServicios : ICliente
    {
        private readonly RestauranteDbContext _RestauranteDbContext;

        public ClienteServicios(RestauranteDbContext context)
        {
            _RestauranteDbContext = context;
        }

        public Cliente AddCliente(Cliente cliente)
        {
            _RestauranteDbContext.Clientes.Add(cliente);
            _RestauranteDbContext.SaveChanges();
            return cliente;
        }

        public Cliente CreateCliente(string nombre, string telefono, string correoElectronico)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAllClientes()
        {
            throw new NotImplementedException();
        }

        public Cliente GetClienteById(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Cliente UpdateCliente(int clienteId, Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
