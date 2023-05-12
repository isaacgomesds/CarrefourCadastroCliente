using CSF.CadastroCliente.Domain.Model;
using CSF.CadastroCliente.Infrastructure.Repositories.Context;
using System;

namespace CSF.CadastroCliente.Infrastructure.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CidadeRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
