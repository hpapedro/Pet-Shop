using PetShop.Data;
using PetShop.Models;
using PetShop.Repositories;
using System.Linq;

public class RelatorioRepository : IRelatorioRepository
{
    private readonly AppDbContext _context;

    public RelatorioRepository(AppDbContext context)
    {
        _context = context;
    }

    public RelatorioGeral ObterTotalEntradas()
    {
        // Supondo que vendas têm valor e estão em _context.Vendas
        decimal totalEntradas = _context.Vendas.Sum(v => v.ValorTotal);
        return new RelatorioGeral { Tipo = "Total Entradas", Total = totalEntradas };
    }

    public RelatorioGeral ObterTotalSaidas()
    {
        // Supondo que contas a pagar têm valor e estão em _context.ContasPagar
        decimal totalSaidas = _context.ContasPagar.Sum(c => c.Valor);
        return new RelatorioGeral { Tipo = "Total Saídas", Total = totalSaidas };
    }
}
