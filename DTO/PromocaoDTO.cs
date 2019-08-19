using MarktSys_ASP_NET_CORE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class PromocaoDTO {

        [Required]
        public int Id { get; set; }

        [Required]
        public virtual ICollection<dynamic> PromocaoProdutos { get; set; }

        [Required]
        public int PercentualDesconto { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFinal { get; set; }

    }
}
