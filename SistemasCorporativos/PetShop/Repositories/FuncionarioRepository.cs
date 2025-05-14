using PetShop.Data;
using PetShop.Models;
using PetShop.Repositories;

namespace PetShop.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _context;

        public FuncionarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Cadastrar(Funcionario funcionario)
        {
            if (funcionario == null)
                throw new ArgumentNullException(nameof(funcionario), "Funcionário não pode ser nulo");

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public Funcionario? BuscarPorId(int id)
        {
            return _context.Funcionarios.Find(id);
        }

        public IEnumerable<Funcionario> ListarTodos()
        {
            return _context.Funcionarios.ToList();
        }

        public void Atualizar(Funcionario funcionario)
        {
            var funcionarioExistente = _context.Funcionarios.Find(funcionario.Id);
            if (funcionarioExistente == null)
                throw new Exception("Funcionário não encontrado");

            // Atualiza os campos
            funcionarioExistente.Nome = funcionario.Nome;
            funcionarioExistente.Cargo = funcionario.Cargo;
            funcionarioExistente.CPF = funcionario.CPF;
            funcionarioExistente.Email = funcionario.Email;
            funcionarioExistente.Telefone = funcionario.Telefone;
            funcionarioExistente.DataAdmissao = funcionario.DataAdmissao;
            funcionarioExistente.Salario = funcionario.Salario;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado");

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

        public bool VerificarSeEmailExiste(string email)
        {
            return _context.Funcionarios.Any(f => f.Email.ToUpper() == email.ToUpper());
        }
    }
}
