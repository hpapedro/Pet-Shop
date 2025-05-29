using PetShop.Data;
using PetShop.Repositories;
using PetShop.Models;

public class ContaPagarRepository : IContaPagarRepository
{
    private readonly AppDbContext _context;

    public ContaPagarRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Adicionar(ContaPagar conta)
    {
        _context.ContasPagar.Add(conta);
        _context.SaveChanges();
    }

    public List<ContaPagar> Listar()
    {
        return _context.ContasPagar.ToList();
    }

    public ContaPagar? BuscarPorId(int id)
    {
        return _context.ContasPagar.Find(id);
    }

    public void Atualizar(ContaPagar conta)
    {
        _context.ContasPagar.Update(conta);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var conta = BuscarPorId(id);
        if (conta is not null)
        {
            _context.ContasPagar.Remove(conta);
            _context.SaveChanges();
        }
    }
}
