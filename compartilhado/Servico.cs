using exemplo.crud.compartilhado.interfaces;

﻿namespace exemplo.crud.compartilhado;

public class Servico<TEntity> : IServico<TEntity> where TEntity : class, IEntidade
{
    protected readonly IRepositorio<TEntity> repositorio;

    public Servico(IRepositorio<TEntity> repositorio)
    {
        this.repositorio = repositorio;
    }

    public virtual async Task<TEntity> Novo(TEntity obj)
    {
        return await repositorio.Novo(obj);
    }

    public virtual async Task<bool> Alterar(TEntity obj)
    {
        return await repositorio.Alterar(obj) > 0;
    }

    public virtual async Task<bool> Remover(object id)
    {
        return await repositorio.Remover(id);
    }

    public virtual async Task<TEntity?> ObterId(object id)
    {
        return await repositorio.ObterId(id);
    }
}