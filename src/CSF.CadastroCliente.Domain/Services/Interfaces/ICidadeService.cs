using System.Threading.Tasks;

namespace CSF.CadastroCliente.Domain.Services.Interfaces
{
    public interface ICidadeService
    {
        Task<bool> EstadoValido(string estado);
    }
}
