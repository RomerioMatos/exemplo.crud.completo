using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using exemplo.crud.core.agregados;

namespace exemplo.crud.infra.data.mapper;

public class ProdutoMapper : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
      builder
        .ToTable("PRODUTOS");

      builder
        .Property(c => c.Id)
        .HasColumnName("ID")
        .IsRequired()
        .HasColumnType("VARCHAR")
        .HasMaxLength(36);
      
      builder
        .Property(c => c.Descricao)
        .HasColumnName("DESCRICAO")
        .IsRequired()
        .HasColumnType("VARCHAR")
        .HasMaxLength(50);

       builder
        .Property(c => c.Unidade)
        .HasColumnName("UNIDADE")
        .HasColumnType("VARCHAR")
        .HasMaxLength(5);

       builder
        .Property(c => c.Preco)
        .HasColumnName("PRECO")
        .IsRequired()
        .HasColumnType("DECIMAL")
        .HasPrecision(13, 2)
        .HasDefaultValue(0);

      builder
        .Property(c => c.Ativo)
        .HasColumnName("ATIVO")
        .IsRequired()
        .HasColumnType("BIT");

       builder
        .Property(c => c.UsuarioInclusao)
        .HasColumnName("USUARIOINCLUSAO")
        .IsRequired()
        .HasColumnType("VARCHAR")
        .HasMaxLength(50);

       builder
        .Property(c => c.DataInclusao)
        .HasColumnName("DATAINCLUSAO")
        .IsRequired()
        .HasColumnType("DATETIME")
        .HasDefaultValue(DateTime.Now);

      builder
        .HasKey(pk => new { pk.Id });
    }
}
