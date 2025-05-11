using System;

namespace PetShop.Models;

public class Financeiro
{
    public int Id {get; set;}
    public string Tipo {get; set;} = string.Empty;
    public decimal Valor {get; set;}
    public bool Quitado {get; set;}
}
