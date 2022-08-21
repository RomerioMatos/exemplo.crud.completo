namespace exemplo.crud.compartilhado.interfaces;

public interface IRepositorio<TEntity> : IDisposable where TEntity : class, IEntidade
{
    Task<TEntity> Novo(TEntity obj);
    Task<int> Alterar(TEntity obj);
    Task<bool> Remover(object id);
    Task<int> Remover(TEntity obj);
    Task<TEntity?> ObterId(object id);
}
