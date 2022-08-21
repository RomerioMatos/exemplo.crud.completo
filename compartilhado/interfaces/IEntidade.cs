namespace exemplo.crud.compartilhado.interfaces;

public interface IEntidade
{
    string Id { get; set; }
    bool Ativo { get; set; }
    string UsuarioInclusao { get; set; }
    DateTime DataInclusao { get; set; }
}
