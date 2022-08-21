using Microsoft.EntityFrameworkCore;
using exemplo.crud.compartilhado.interfaces;

namespace exemplo.crud.infra.data;

public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class, IEntidade
{
    protected readonly DataContexto dbContext;
    protected readonly DbSet<TEntity> dbSet;

    protected Repositorio(DataContexto dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = this.dbContext.Set<TEntity>();
    }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public virtual async Task<TEntity> Novo(TEntity obj)
    {
        var r = await dbSet.AddAsync(obj);
        await dbContext.SaveChangesAsync();
        return r.Entity;
    }

    public virtual async Task<int> Alterar(TEntity obj)
    {
        dbContext.Entry(obj).State = EntityState.Modified;
        return await Task.FromResult<int>(
            await dbContext.SaveChangesAsync()
        );
    }

    public virtual async Task<int> Remover(TEntity obj)
    {
        dbSet.Remove(obj);
        return await Task.FromResult<int>(
            await dbContext.SaveChangesAsync()
        );
    }

    public virtual async Task<bool> Remover(object id)
    {
        var entidade = await ObterId(id);

        return entidade == null ? 
          await Task.FromResult<bool>(false) : 
          await Remover(entidade) > 0;
    }

    public virtual async Task<TEntity?> ObterId(object id)
    {
        return await dbSet.FindAsync(id);
    }
}
