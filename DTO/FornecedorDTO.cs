using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class FornecedorDTO {

        [Required]
        public int Id { get; set; }


        [Required]
        [MinLength(3, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        [MaxLength(60, ErrorMessage = "Tamanho mínimo necessário: 3 dígitos!")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Número de telefone inválido!!")]
        public string Telefone { get; set; }

    }
}
