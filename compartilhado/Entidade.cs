using exemplo.crud.compartilhado.interfaces;

﻿namespace exemplo.crud.compartilhado;

public class Entidade : IEntidade
{
    public string Id { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string UsuarioInclusao { get; set; } = string.Empty;
    public DateTime DataInclusao { get; set; }
}
