using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        // POST para registrar um novo funcionário
        [HttpPost("registrar")]
        public ActionResult<Funcionario> CadastrarFuncionario([FromBody] Funcionario funcionario)
        {
            if (funcionario == null)
                return BadRequest("Funcionário não pode ser nulo");

            if (_funcionarioRepository.VerificarSeEmailExiste(funcionario.Email))
                return Conflict("Funcionário com esse email já existe");

            _funcionarioRepository.Cadastrar(funcionario);
            return CreatedAtAction(nameof(BuscarFuncionarioPorId), new { id = funcionario.Id }, funcionario);
        }

        // GET para buscar um funcionário por ID
        [HttpGet("buscar/{id}")]
        public ActionResult<Funcionario> BuscarFuncionarioPorId(int id)
        {
            var funcionario = _funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
                return NotFound("Funcionário não encontrado");

            return Ok(funcionario);
        }

        // GET para listar todos os funcionários
        [HttpGet("listar")]
        public ActionResult<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            var funcionarios = _funcionarioRepository.ListarTodos();
            return Ok(funcionarios);
        }

        // PUT para atualizar os dados de um funcionário
        [HttpPut("atualizar/{id}")]
        public ActionResult AtualizarFuncionario(int id, [FromBody] Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return BadRequest("ID do funcionário não confere");

            var funcionarioExistente = _funcionarioRepository.BuscarPorId(id);
            if (funcionarioExistente == null)
                return NotFound("Funcionário não encontrado");

            _funcionarioRepository.Atualizar(funcionario);
            return Ok("Funcionário atualizado com sucesso");
        }

        // DELETE para remover um funcionário
        [HttpDelete("deletar/{id}")]
        public ActionResult RemoverFuncionario(int id)
        {
            var funcionario = _funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
                return NotFound("Funcionário não encontrado");

            _funcionarioRepository.Remover(id);
            return Ok("Funcionário Deletado com sucesso!");
        }
    }
}
