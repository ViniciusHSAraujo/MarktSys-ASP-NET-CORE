using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class CategoriaDTO {

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher um nome!")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        [MaxLength(60, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        public string Nome { get; set; }

    }
}
