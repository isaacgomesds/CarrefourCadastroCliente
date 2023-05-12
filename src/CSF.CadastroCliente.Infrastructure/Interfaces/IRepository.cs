namespace CSF.CadastroCliente.Infrastructure.Interfaces
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
    }
}
