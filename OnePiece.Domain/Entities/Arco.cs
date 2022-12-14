using OnePiece.Domain.Validation;

namespace OnePiece.Domain.Entities
{
    public sealed class Arco : Entity
    {
        public Arco(string nome, string imagemUrl, string volumes, string capitulosManga, string anoLancamento,
            string descricao)
        {
            ValidateDomain(nome, imagemUrl, volumes, capitulosManga, anoLancamento, descricao);
        }

        public Arco(int id, string nome, string imagemUrl, string volumes, string capitulosManga, string anoLancamento,
            string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");
            Id = id;
            ValidateDomain(nome, imagemUrl, volumes, capitulosManga, anoLancamento, descricao);
        }

        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Volumes { get; private set; }
        public string CapitulosManga { get; private set; }
        public string AnoLancamento { get; private set; }
        public string Descricao { get; private set; }

        private void ValidateDomain(string nome, string imagemUrl, string volumes, string capitulosManga, string anoLancamento,
            string descricao)
        {
            // Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 13,
                "O nome deve ter no mínimo 13 caracteres");

            DomainExceptionValidation.When(nome.Length > 17,
                "O nome deve ter no maximo 17 caracteres");

            // ImagemUrl
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "Imagem URL inválida. Imagem URL é obrigatório");

            DomainExceptionValidation.When(imagemUrl.Length < 4,
                "Imagem URL inválida. Imagem URL deve ter no mínimo 4 caracteres");

            DomainExceptionValidation.When(imagemUrl.Length > 300,
                "Imagem URL inválida. Imagem URL deve ter no máximo 300");

            // Volumes
            DomainExceptionValidation.When(string.IsNullOrEmpty(volumes),
                "Volumes inválido. Volumes é obrigatório");

            DomainExceptionValidation.When(volumes.Length < 1,
                "Volumes inválido. Volumes deve ter no mínimo 1 caracteres");

            DomainExceptionValidation.When(volumes.Length > 8,
                "Volumes inválido. Volumes deve ter no máximo 8 caracteres");

            // Capitulos Manga
            DomainExceptionValidation.When(string.IsNullOrEmpty(capitulosManga),
                "Capitulos manga inválido. Capitulos manga é obrigatório");

            DomainExceptionValidation.When(capitulosManga.Length < 1,
                "Capitulos manga inválido. Capitulos manga deve ter no mínimo 1 caracteres");

            DomainExceptionValidation.When(capitulosManga.Length > 11,
                "Capitulos manga inválido. Capitulos manga deve ter no máximo 11 caracteres");

            // Ano Lançamento
            DomainExceptionValidation.When(string.IsNullOrEmpty(anoLancamento),
                "Ano de lançamento inválido. Ano de lançamento é obrigatório");

            DomainExceptionValidation.When(anoLancamento.Length < 1,
                "Ano de lançamento inválido. Ano de lançamento deve ter no mínimo 1 caracteres");

            DomainExceptionValidation.When(anoLancamento.Length > 9,
                "Ano de lançamento inválido. Ano de lançamento deve ter no máximo 9");

            // Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 30,
                "Descrição inválida. Descrição deve ter no mínimo 1000 caracteres");

            DomainExceptionValidation.When(descricao.Length > 20000,
                "Descrição inválida. Descrição deve ter no máximo 20.000 caracteres");

            Nome = nome;
            ImagemUrl = imagemUrl;
            Volumes = volumes;
            CapitulosManga = capitulosManga;
            AnoLancamento = anoLancamento;
            Descricao = descricao;
        }
    }
}
