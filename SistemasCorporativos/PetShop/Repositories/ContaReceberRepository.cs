using PetShop.Data;
using PetShop.Repositories;
using PetShop.Models;
public class ContaReceberRepository : IContaReceberRepository
{
    private readonly AppDbContext _context;

    public ContaReceberRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Adicionar(ContaReceber conta)
    {
        _context.ContasReceber.Add(conta);
        _context.SaveChanges();
    }

    public List<ContaReceber> Listar()
    {
        return _context.ContasReceber.ToList();
    }

    public void Receber(int id)
    {
        var conta = _context.ContasReceber.Find(id);
        if (conta != null)
        {
            conta.Recebido = true;
            _context.SaveChanges();
        }
    }
}
