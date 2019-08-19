using System;
using System.Collections.Generic;

namespace MarktSys_ASP_NET_CORE.Models {
    public class Promocao {

        public int Id { get; set; }

        public virtual ICollection<PromocaoProduto> PromocaoProdutos { get; set; }

        public int PercentualDesconto { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFinal { get; set; }

    }
}
