using exemplo.crud.compartilhado;

namespace exemplo.crud.core.agregados;

public class Produto: Entidade
{
    public string Descricao { get; set; } = string.Empty;
    public string Unidade { get; set; } = string.Empty;
    public decimal Preco { get; set; } = 0;
}
