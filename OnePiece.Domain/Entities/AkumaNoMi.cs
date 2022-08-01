using OnePiece.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Domain.Entities
{
    public sealed class AkumaNoMi : Entity
    {
        public AkumaNoMi(string nome, string tipo, string primeiraAparicao, string imagemUrl, string descricao)
        {
            ValidateDomain(nome, tipo, primeiraAparicao, imagemUrl, descricao);
        }

        public AkumaNoMi(int id, string nome, string tipo, string primeiraAparicao, string imagemUrl, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, tipo, primeiraAparicao, imagemUrl, descricao);
        }

        public string Nome { get; private set; }
        public string Tipo { get; set; }
        public string PrimeiraAparicao { get; set; }
        public string ImagemUrl { get; set; }
        public string Descricao { get; set; }
        public ICollection<Personagem> Personagens { get; set; }

        private void ValidateDomain(string nome, string tipo, string primeiraAparicao, string imagemUrl, string descricao)
        {
            // Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 13,
                "O nome deve ter no mínimo 13 caracteres");

            DomainExceptionValidation.When(nome.Length > 17,
                "O nome deve ter no maximo 17 caracteres");

            // Tipo
            DomainExceptionValidation.When(string.IsNullOrEmpty(tipo),
                "Tipo inválido. O tipo é obrigatório");

            DomainExceptionValidation.When(tipo.Length < 4,
                "Tipo inválido. Tipo deve ter no mínimo 10 caracteres");

            DomainExceptionValidation.When(tipo.Length > 9,
                "Tipo inválido. Tipo deve ter no máximo 9");

            // Primeira Aparição
            DomainExceptionValidation.When(string.IsNullOrEmpty(primeiraAparicao),
                "Primeira aparição inválida. A primeira aparição é obrigatória");

            DomainExceptionValidation.When(primeiraAparicao.Length < 10,
                "Primeira aparição inválida. Primeira aparição deve ter no mínimo 10 caracteres");

            DomainExceptionValidation.When(primeiraAparicao.Length > 200,
                "Primeira aparição inválida. Primeira aparição deve ter no máximo 200");

            // ImagemUrl
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "ImagemUrl inválida. A ImagemUrl é obrigatória");

            DomainExceptionValidation.When(imagemUrl.Length > 300,
                "ImagemUrl inválida. ImagemUrl deve ter no máximo 300 caracteres");

            // Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 1000,
                "Descrição inválida. Descrição deve ter no mínimo 1000 caracteres");

            DomainExceptionValidation.When(descricao.Length > 20000,
                "Descrição inválida. Descrição deve ter no máximo 20.000 caracteres");

            Nome = nome;
            Tipo = tipo;    
            PrimeiraAparicao = primeiraAparicao;
            ImagemUrl = imagemUrl;
            Descricao = descricao;
        }
    }
}
