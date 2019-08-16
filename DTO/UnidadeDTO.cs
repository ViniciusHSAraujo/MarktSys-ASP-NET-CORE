using System.ComponentModel.DataAnnotations;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class UnidadeDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        [MaxLength(60, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        public string Nome { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Tamanho necessário: 2 dígitos!")]
        public string Simbolo { get; set; }

    }
}
