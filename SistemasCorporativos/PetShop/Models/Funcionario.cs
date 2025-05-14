using System;

namespace PetShop.Models;

public class Funcionario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Cargo {get;set;} = string.Empty;
    public string CPF {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public DateTime DataAdmissao {get; set;}
    public decimal Salario {get; set;}

}
