using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Infrastructure.Interfaces;
using CSF.CadastroCliente.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSF.CadastroCliente.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IApplicationReadDbConnection _readDbConnection;
        private readonly IApplicationReadWriteDbConnection _writeDbConnection;

        public ClienteRepository(ApplicationDbContext dbContext, IApplicationReadDbConnection readDbConnection, IApplicationReadWriteDbConnection writeDbConnection) 
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _readDbConnection = readDbConnection ?? throw new ArgumentNullException(nameof(readDbConnection));
            _writeDbConnection = writeDbConnection ?? throw new ArgumentNullException(nameof(writeDbConnection));
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _dbContext.Clientes
                .Include(e => e.Enderecos)
                .ThenInclude(e => e.Endereco)
                .ThenInclude(e => e.Cidade)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async override Task<int> UpdateAsync(Cliente entity, CancellationToken cancellationToken = default)
        {
            var existenteCLienteEnderecos = await _dbContext.CLienteEnderecos.Where(e => e.ClienteId == entity.Id).ToListAsync();
            
            _dbContext.RemoveRange(existenteCLienteEnderecos);

            return await base.UpdateAsync(entity, cancellationToken);
        }

        public async override Task<int> DeleteAsync(Cliente entity, CancellationToken cancellationToken = default)
        {
            var enderecos = await _dbContext.Enderecos.Where(e => e.ClienteEndereco.ClienteId == entity.Id).ToListAsync();

            _dbContext.RemoveRange(enderecos);
            
            return await base.DeleteAsync(entity, cancellationToken);
        }
    }
}
