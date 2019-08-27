using System.ComponentModel.DataAnnotations;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class ProdutoDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        [MaxLength(60, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        public string Nome { get; set; }

        [Required]
        public int CategoriaID { get; set; }

        [Required]
        public int FornecedorID { get; set; }

        [Required(ErrorMessage = "É obrigatório preencher esse campo!")]
        public float PrecoCusto { get; set; }

        [Required(ErrorMessage = "É obrigatório preencher esse campo!")]
        public string PrecoCustoString { get; set; }

        [Required(ErrorMessage = "É obrigatório preencher esse campo!")]
        public float PrecoVenda { get; set; }

        [Required(ErrorMessage = "É obrigatório preencher esse campo!")]
        public string PrecoVendaString { get; set; }

        [Required]
        public int UnidadeID { get; set; }
    }
}
