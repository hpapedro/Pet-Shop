using PetShop.Models;

namespace PetShop.Repositories;

public interface IFuncionarioRepository
{
    void Cadastrar(Funcionario funcionario);
    Funcionario? BuscarPorId(int id);
    IEnumerable<Funcionario> ListarTodos();
    void Atualizar(Funcionario funcionario);
    void Remover(int id);
    bool VerificarSeEmailExiste(string email);
}

