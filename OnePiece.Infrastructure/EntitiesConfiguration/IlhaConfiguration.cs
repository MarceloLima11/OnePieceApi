using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnePiece.Domain.Entities;

namespace OnePiece.Infrastructure.EntitiesConfiguration
{
    public class IlhaConfiguration
    {
        public void Configure(EntityTypeBuilder<Ilha> builder)
        {
            builder.ToTable("tb_ilhas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(19).IsRequired();
            builder.Property(x => x.Regiao).HasColumnName("regiao").HasMaxLength(8).IsRequired();
            builder.Property(x => x.ImagemUrl).HasColumnName("clima").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(20000).IsRequired();
            builder.Property(x => x.ImagemUrl).HasColumnName("imagem_link").HasMaxLength(300).IsRequired();
        }
    }
}
