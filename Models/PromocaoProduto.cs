using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.Models {
    public class PromocaoProduto {

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }

    }
}
