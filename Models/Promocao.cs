﻿using System;
using System.Collections.Generic;

namespace MarktSys_ASP_NET_CORE.Models {
    public class Promocao {

        public int Id { get; set; }

        public ICollection<PromocaoProduto> PromocaoProdutos { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public int PercentualDesconto { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFinal { get; set; }

    }
}
