using PetShop.Data;
using PetShop.Repositories;
using PetShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CadastrarVenda(Venda venda)
    {
        _context.Vendas.Add(venda);
        _context.SaveChanges();
    }
    public Venda? BuscarPorId(int id)
    {
        return _context.Vendas
            .Include(v => v.Itens)
            .ThenInclude(i => i.Produto)
            .FirstOrDefault(v => v.Id == id);
    }


    public List<Venda> ListarTodas()
    {
        return _context.Vendas
            .Include(v => v.Itens)
            .ThenInclude(i => i.Produto)
            .ToList();
    }

    public void AtualizarVenda(Venda venda)
    {
        _context.Vendas.Update(venda);
        _context.SaveChanges();
    }

    public void RemoverVenda(int id)
    {
        var venda = _context.Vendas.Find(id);
        if (venda != null)
        {
            _context.Vendas.Remove(venda);
            _context.SaveChanges();
        }
    }

}
