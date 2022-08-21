using exemplo.crud.compartilhado;
using exemplo.crud.core.interfaces;
using exemplo.crud.core.agregados;

namespace exemplo.crud.core.servicos;

public class ProdutoServico: Servico<Produto>, IProdutoServico
{
    public ProdutoServico(IProdutoRepositorio repositorio): base(repositorio){}
}
