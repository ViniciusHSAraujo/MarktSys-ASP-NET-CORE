using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarktSys_ASP_NET_CORE.Models {
    public class Categoria {

        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Status { get; set; }

    }
}
