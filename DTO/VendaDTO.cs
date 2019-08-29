using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.DTO {
    public class VendaDTO {

        public float Total { get; set; }

        public float Troco { get; set; }

        public SaidaDTO[] Produtos { get; set; }

    }
}
