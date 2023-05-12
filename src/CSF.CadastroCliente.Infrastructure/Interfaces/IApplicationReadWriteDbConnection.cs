using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Infrastructure.Interfaces
{
    public interface IApplicationReadWriteDbConnection : IApplicationReadDbConnection
    {
        Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);
    }
}
