using exemplo.crud.infra.data;
using exemplo.crud.core.interfaces;
using exemplo.crud.core.agregados;

namespace exemplo.crud.infra.repositorios;

public class ProdutoRepositorio: Repositorio<Produto>, IProdutoRepositorio
{
    public ProdutoRepositorio(DataContexto dbContext): base(dbContext){}
}