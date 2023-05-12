using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Domain.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Domain.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository ?? throw new InvalidDataException("ClienteRepository não pode ser nulo");
        }


        public async Task<bool> EstadoValido(string estado)
        {
            return await _cidadeRepository.AnyAsync(x => x.Estado.ToUpper() == estado.ToUpper());
        }
    }
}
