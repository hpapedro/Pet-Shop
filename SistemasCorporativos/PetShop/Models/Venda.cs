using System;

namespace PetShop.Models
{
    public enum StatusVenda
    {
        NoCarrinho,
        PagamentoPendente,
        Pago,
        Entregue
    }

    public class Venda
    {
        public int Id { get; set; }
        public string? ClienteNome { get; set; } 
        public DateTime DataVenda { get; set; }
        public StatusVenda Status { get; set; } = StatusVenda.NoCarrinho;
        public decimal ValorTotal { get; set; }

        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }

    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public Produto? Produto { get; set; }
    }
}