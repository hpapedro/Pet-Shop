using System.Collections.Generic;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Repositories
{
public interface IProdutoRepository
{
    void Cadastrar(Produto produto);
    IEnumerable<Produto> ListarTodos();
    Produto? BuscarPorId(int id);
    void Atualizar(Produto produto);
    void Remover(int id);
}
}
