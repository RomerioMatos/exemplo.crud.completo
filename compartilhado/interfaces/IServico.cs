namespace exemplo.crud.compartilhado.interfaces;

public interface IServico<TEntity> where TEntity : class, IEntidade
{
    Task<TEntity> Novo(TEntity obj);
    Task<bool> Alterar(TEntity obj);
    Task<bool> Remover(object id);
    Task<TEntity?> ObterId(object id);
}
