using System;

namespace PetShop.Models;

public class ContaPagar
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public bool Pago { get; set; } = false;
    public string Fornecedor { get; set; } = string.Empty;
}
