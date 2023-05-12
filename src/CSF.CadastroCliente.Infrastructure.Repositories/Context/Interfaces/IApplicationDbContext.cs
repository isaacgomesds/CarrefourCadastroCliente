using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context.Interfaces
{
    public interface IApplicationDbContext : IUnitOfWork
    {
        public DbSet<Cliente> Clientes { get; }
        public DbSet<Endereco> Enderecos { get; }
        public DbSet<ClienteEndereco> CLienteEnderecos { get; }
        public DbSet<Cidade> Cidades { get; }

        public IDbConnection Connection { get; }
    }
}
