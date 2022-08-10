using System.ComponentModel.DataAnnotations;

namespace OnePiece.Application.DTOs
{
    public class ArcoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string ImagemUrl { get; set; }
        [Required]
        public string Volumes { get; set; }
        [Required]
        public string CapitulosManga { get; set; }
        [Required]
        public string EpisodiosAnime { get; set; }
        [Required]
        public string AnoLancamento { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
