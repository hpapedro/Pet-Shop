using System;

namespace PetShop.Models;

public class ContaReceber
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Recebido { get; set; }
    public string Cliente { get; set; } = string.Empty;
}

