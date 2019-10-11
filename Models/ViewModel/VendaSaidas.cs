using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.Models.ViewModel {
    public class VendaSaidas {

        public Venda Venda { get; set; }

        public List<Saida> Saidas { get; set; }
    }
}
