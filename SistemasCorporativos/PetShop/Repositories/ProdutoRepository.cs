using PetShop.Data;
using PetShop.Models;
using PetShop.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Cadastrar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public IEnumerable<Produto> ListarTodos()
    {
        return _context.Produtos.ToList();
    }

    public Produto? BuscarPorId(int id)
    {
        return _context.Produtos.Find(id);
    }

    public void Atualizar(Produto produto)
    {
        var existente = _context.Produtos.Find(produto.Id);
        if (existente != null)
        {
            existente.Nome = produto.Nome;
            existente.Descricao = produto.Descricao;
            existente.Categoria = produto.Categoria;
            existente.Preco = produto.Preco;
            existente.QuantidadeEmEstoque = produto.QuantidadeEmEstoque;
            existente.DataCadastro = produto.DataCadastro;
            existente.Fornecedor = produto.Fornecedor;

            _context.SaveChanges();
        }
    }

    public void Remover(int id)
    {
        var produto = BuscarPorId(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

    }

    public IEnumerable<object> ListarEstoqueSimplificado()
    {
        return _context.Produtos
            .Select(p => new
            {
                p.Nome,
                p.QuantidadeEmEstoque
            })
            .ToList<object>();
    }

}
