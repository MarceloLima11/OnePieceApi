using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnePiece.Domain.Entities;

namespace OnePiece.Infrastructure.EntitiesConfiguration
{
    public class PersonagemConfiguration : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.ToTable("tb_personagens");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(25).IsRequired();
            builder.Property(x => x.Idade).HasColumnName("idade");
            builder.Property(x => x.Linhagem).HasColumnName("linhagem").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Altura).HasColumnName("altura").IsRequired();
            builder.Property(x => x.Vivo).HasColumnName("vivo").HasDefaultValue(true).IsRequired();
            builder.Property(x => x.Recompensa).HasColumnName("recompensa").HasMaxLength(13).IsRequired();
            builder.Property(x => x.FraseMarcante).HasColumnName("frase_marcante").HasMaxLength(300).IsRequired();
            builder.Property(x => x.PrimeiraAparicao).HasColumnName("primeira_aparicao").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(20000).IsRequired();
            builder.Property(x => x.ImagemUrl).HasColumnName("imagem_link").HasMaxLength(300).IsRequired();
            builder.Property(x => x.TopCinco).HasColumnName("top_cinco").HasDefaultValue(false).IsRequired();

            // 

            builder.HasOne(x => x.AkumaNoMi).WithMany(x => x.Personagens).HasForeignKey(x => x.AkumaNoMiId);
        }
    }
}
