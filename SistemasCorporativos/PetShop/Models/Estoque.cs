using System;

namespace PetShop.Models;

public class Estoque
{
    public int Id {get; set;}
    public int ProdutoId {get;set;}
    public required Produto Produto {get; set;}
    public int Quantidade {get; set;}
}
