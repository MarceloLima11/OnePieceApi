using OnePiece.Domain.Validation;

namespace OnePiece.Domain.Entities
{
    public class Ilha : Entity
    {
        public Ilha(string nome, string regiao, string clima, string descricao, string imagemUrl)
        {
            ValidateDomain(nome, regiao, clima, descricao, imagemUrl);
        }

        public Ilha(int id, string nome, string regiao, string clima, string descricao, string imagemUrl)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, regiao, clima, descricao, imagemUrl);
        }

        public string Nome { get; private set; }
        public string Regiao { get; private set; }
        public string Clima { get; private set; }
        public string Descricao { get; private set; }
        public string ImagemUrl { get; private set; }

        private void ValidateDomain(string nome, string regiao, string clima, string descricao, string imagemUrl)
        {
            // Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 13 caracteres");

            DomainExceptionValidation.When(nome.Length > 19,
                "O nome deve ter no maximo 17 caracteres");

            // Regiao 
            DomainExceptionValidation.When(string.IsNullOrEmpty(regiao),
                "Regiao inválido. Regiao é obrigatório");

            DomainExceptionValidation.When(regiao.Length < 1,
                "Regiao inválido. Regiao deve ter no mínimo 1 caracteres");

            DomainExceptionValidation.When(regiao.Length > 12,
                "Regiao inválido. Regiao deve ter no máximo 8 caracteres");

            // Clima
            DomainExceptionValidation.When(string.IsNullOrEmpty(clima),
                "Clima inválido. Clima é obrigatório");

            DomainExceptionValidation.When(clima.Length < 1,
                "Clima inválido. Clima deve ter no mínimo 1 caracteres");

            DomainExceptionValidation.When(clima.Length > 20,
                "Clima inválido. Clima deve ter no máximo 8 caracteres");

            // Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 1000,
                "Descrição inválida. Descrição deve ter no mínimo 1000 caracteres");

            DomainExceptionValidation.When(descricao.Length > 20000,
                "Descrição inválida. Descrição deve ter no máximo 20.000 caracteres");

            // ImagemUrl
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "Imagem URL inválida. Imagem URL é obrigatório");

            DomainExceptionValidation.When(imagemUrl.Length < 4,
                "Imagem URL inválida. Imagem URL deve ter no mínimo 4 caracteres");

            DomainExceptionValidation.When(imagemUrl.Length > 300,
                "Imagem URL inválida. Imagem URL deve ter no máximo 300");


            Nome = nome;
            Regiao = regiao;
            Clima = clima;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
        }
    }
}
