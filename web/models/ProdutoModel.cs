namespace exemplo.crud.web.models;

public class ProdutoModel
{
    public string Id { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Unidade { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
