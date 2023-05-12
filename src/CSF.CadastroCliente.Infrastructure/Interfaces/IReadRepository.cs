namespace CSF.CadastroCliente.Infrastructure.Interfaces
{
    public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> 
        where TEntity : class 
    { 
    }
}
