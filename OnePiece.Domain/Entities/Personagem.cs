using OnePiece.Domain.Validation;

namespace OnePiece.Domain.Entities
{
    public sealed class Personagem : Entity
    {
        public Personagem(string nome, int idade, string linhagem, string altura, bool vivo, string recompensa,
            string fraseMarcante, string primeiraAparicao, string descricao, string imagemUrl, bool topCinco)
        {
            ValidateDomain(nome, idade, linhagem, altura, vivo, recompensa, fraseMarcante, primeiraAparicao,
                descricao, imagemUrl, topCinco);
        }

        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Linhagem { get; private set; }
        public string Altura { get; private set; }
        public bool Vivo { get; private set; }
        public string Recompensa { get; private set; }
        public string FraseMarcante { get; private set; }
        public string PrimeiraAparicao { get; private set; }
        public string Descricao { get; private set; }
        public string ImagemUrl { get; private set; }
        public bool TopCinco { get; private set; }

        public void Update(string nome, int idade, string linhagem, string altura, bool vivo, string recompensa,
            string fraseMarcante, string primeiraAparicao, string descricao, string imagemUrl, bool topCinco, int akumaId)
        {
            ValidateDomain(nome, idade, linhagem, altura, vivo, recompensa, fraseMarcante, primeiraAparicao,
                descricao, imagemUrl, topCinco);
            AkumaNoMiId = akumaId;
        }

        private void ValidateDomain(string nome, int idade, string linhagem, string altura, bool vivo, string recompensa,
            string fraseMarcante, string primeiraAparicao, string descricao, string imagemUrl, bool topCinco)
        {

            // Nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(nome.Length > 25,
                "O nome deve ter no maximo 25 caracteres");

            // Idade
            DomainExceptionValidation.When(idade < 0, 
                "Idade inválida. Idade deve ser maior que 0");

            DomainExceptionValidation.When(idade > 1000,
                "Idade inválida. Idade deve ser menor que 1000");

            // Linhagem
            DomainExceptionValidation.When(string.IsNullOrEmpty(linhagem),
                "Linhagem inválida. Linhagem é obrigatória");

            DomainExceptionValidation.When(linhagem.Length < 5,
                "A linhagem deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(linhagem.Length > 100,
                "A linhagem deve ter no maximo 100 caracteres");

            // Altura
            DomainExceptionValidation.When(string.IsNullOrEmpty(altura),
                "Altura inválida. A altura é obrigatória");

            DomainExceptionValidation.When(altura.Length < 2,
                "Altura inválida. Altura deve ser maior que 2");

            DomainExceptionValidation.When(altura.Length > 6,
                "Altura inválida. Altura deve ser menor que 6");

            // Recompensa
            DomainExceptionValidation.When(string.IsNullOrEmpty(recompensa),
                "Recompensa inválida. A recompensa é obrigatória");

            DomainExceptionValidation.When(recompensa.Length < 3,
                "Recompensa inválida. Recompensa deve ser maior que 3");

            DomainExceptionValidation.When(recompensa.Length > 13,
                "Recompensa inválida. Recompensa deve ser menor que 13");

            // Frase Marcante
            DomainExceptionValidation.When(string.IsNullOrEmpty(fraseMarcante),
                "Frase inválida. A frase é obrigatória");

            DomainExceptionValidation.When(fraseMarcante.Length < 10,
                "Frase inválida. Frase marcante deve ter no mínimo 10 caracteres");

            DomainExceptionValidation.When(fraseMarcante.Length > 300,
                "Frase inválida. Frase marcante deve ter no máximo 300 caracteres");

            // Primeira Aparição
            DomainExceptionValidation.When(string.IsNullOrEmpty(primeiraAparicao),
                "Primeira aparição inválida. A primeira aparição é obrigatória");

            DomainExceptionValidation.When(primeiraAparicao.Length < 10,
                "Primeira aparição inválida. Primeira aparição deve ter no mínimo 10 caracteres");

            DomainExceptionValidation.When(primeiraAparicao.Length > 200,
                "Primeira aparição inválida. Primeira aparição deve ter no máximo 200");

            // Descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 1000,
                "Descrição inválida. Descrição deve ter no mínimo 1000 caracteres");

            DomainExceptionValidation.When(descricao.Length > 20000,
                "Descrição inválida. Descrição deve ter no máximo 20.000 caracteres");

            // ImagemUrl
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "ImagemUrl inválida. A ImagemUrl é obrigatória");

            DomainExceptionValidation.When(imagemUrl.Length > 300,
                "ImagemUrl inválida. ImagemUrl deve ter no máximo 300 caracteres");

            Nome = nome;
            Idade = idade;
            Linhagem = linhagem;
            Altura = altura;    
            Vivo = vivo;
            Recompensa = recompensa;
            FraseMarcante = fraseMarcante;  
            PrimeiraAparicao = primeiraAparicao;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            TopCinco = topCinco;
            
        }
        public int AkumaNoMiId { get; set; }
        public AkumaNoMi AkumaNoMi { get; set; }
    }
}
