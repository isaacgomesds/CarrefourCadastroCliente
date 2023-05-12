using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Infrastructure.Repositories.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace CSF.CadastroCliente.Infrastructure.Repositories.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Endereco> Enderecos => Set<Endereco>();
        public DbSet<ClienteEndereco> CLienteEnderecos => Set<ClienteEndereco>();
        public DbSet<Cidade> Cidades => Set<Cidade>();

        public IDbConnection Connection => Database.GetDbConnection();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
