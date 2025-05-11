using System;

namespace PetShop.Models;

public class Funcionario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Email{get; set;} = string.Empty;
    public string Senha{get; set;} = string.Empty;
    public string Role{get; set;} = string.Empty;
}
