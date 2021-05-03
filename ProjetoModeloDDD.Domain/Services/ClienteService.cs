using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly ICienteRepository _cienteRepository;

        public ClienteService(ICienteRepository clienteRepository) : base(clienteRepository)
        {
            _cienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspecias(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
