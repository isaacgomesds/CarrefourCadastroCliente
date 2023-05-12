using CSF.CadastroCliente.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Domain.Model
{
    public interface IClienteRepository : IRepository<Cliente>, IReadRepository<Cliente>
    {
        Task<Cliente> GetClienteByIdAsync(int id);
    }
}
