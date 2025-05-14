using System;

namespace PetShop.Models;

public class Produto
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public string Categoria {get; set;} = string.Empty;
    public decimal Preco {get; set;} 
    public int QuantidadeEmEstoque {get; set;}
    public DateTime DataCadastro {get; set;} = DateTime.UtcNow;
    public string Fornecedor {get; set;} = string.Empty;
}
