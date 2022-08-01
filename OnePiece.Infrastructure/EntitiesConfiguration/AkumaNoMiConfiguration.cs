using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnePiece.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure.EntitiesConfiguration
{
    public class AkumaNoMiConfiguration : IEntityTypeConfiguration<AkumaNoMi>
    {
        public void Configure(EntityTypeBuilder<AkumaNoMi> builder)
        {
            builder.ToTable("tb_akumas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(17).IsRequired();
            builder.Property(x => x.Tipo).HasColumnName("tipo").HasMaxLength(9).IsRequired();
            builder.Property(x => x.PrimeiraAparicao).HasColumnName("primeira_aparicao").HasMaxLength(200).IsRequired();
            builder.Property(x => x.ImagemUrl).HasColumnName("imagem_link").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(20000).IsRequired();
        }
    }
}
