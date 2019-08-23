namespace MarktSys_ASP_NET_CORE.Models {
    public class Estoque {

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public float Saldo { get; set; }

    }
}
