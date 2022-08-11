using System.ComponentModel.DataAnnotations;

namespace OnePiece.Application.DTOs
{
    public class IlhaDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Maximo de 10 minimo de 3")]
        public string Regiao { get; set; }
        [Required]
        public string Clima { get; set; }
        [Required]
        public string Descricao { get; set; }
        [StringLength(300, ErrorMessage = "Maximo de 300")]
        [Required]
        public string ImagemUrl { get; set; }
    }
}
