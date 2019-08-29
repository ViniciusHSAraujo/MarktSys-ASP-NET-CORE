using System;

namespace MarktSys_ASP_NET_CORE.Models {
    public class Saida {

        public int Id { get; set; }

        public Produto Produto { get; set; }

        public float Quantidade { get; set; }

        public float ValorDaVenda { get; set; }

        public DateTime DataDaVenda { get; set; }

        public Venda Venda { get; set; }

    }
}
