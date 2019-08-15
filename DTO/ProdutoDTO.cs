using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [Required]
        [Range(0, 9999999.99, ErrorMessage ="Valor inválido!")]
        public float PrecoCusto { get; set; }

        [Required]
        [Range(0, 9999999.99, ErrorMessage = "Valor inválido!")]
        public float PrecoVenda { get; set; }


        [Required]
        public int UnidadeID { get; set; }
    }
}
