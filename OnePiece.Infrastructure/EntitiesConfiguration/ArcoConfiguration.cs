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
    public class ArcoConfiguration : IEntityTypeConfiguration<Arco>
    {
        public void Configure(EntityTypeBuilder<Arco> builder)
        {
            builder.ToTable("tb_arcos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(17).IsRequired();
            builder.Property(x => x.ImagemUrl).HasColumnName("imagem_link").HasMaxLength(300).IsRequired();
            builder.Property(x => x.Volumes).HasColumnName("volumes").HasMaxLength(8).IsRequired();
            builder.Property(x => x.CapitulosManga).HasColumnName("capitulos_manga").HasMaxLength(11).IsRequired();
            builder.Property(x => x.AnoLancamento).HasColumnName("ano_lancamento").HasMaxLength(9).IsRequired();         
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(20000).IsRequired();
        }

        /*public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Volumes { get; private set; }
        public string CapitulosManga { get; private set; }
        public string AnoLancamento { get; private set; }
        public string Descricao { get; private set; }*/
    }
}
