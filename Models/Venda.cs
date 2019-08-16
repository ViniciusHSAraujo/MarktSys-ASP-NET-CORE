using System;

namespace MarktSys_ASP_NET_CORE.Models {
    public class Venda {

        public int Id { get; set; }

        public DateTime DataDaVenda { get; set; }

        public float ValorTotal { get; set; }

        public float ValorPago { get; set; }

        public float ValorDoTroco { get; set; }

    }
}
