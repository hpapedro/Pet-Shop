using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;
using PetShop.Repositories;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Gerente")]
        public ActionResult Cadastrar([FromBody] Produto produto)
        {
            _repository.Cadastrar(produto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = produto.Id }, produto);
        }

        [HttpGet("listar")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Produto>> Listar()
        {
            return Ok(_repository.ListarTodos());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<Produto> BuscarPorId(int id)
        {
            var produto = _repository.BuscarPorId(id);
            if (produto == null)
                return NotFound("Produto não Encontrado");
            
            return Ok(produto);
        }

        [HttpPut("atualizar/{id}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult Atualizar (int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest("Ids não correspondem");

            var existente = _repository.BuscarPorId(id);
            if (existente == null)
                return NotFound("Produto não encontrado");

            _repository.Atualizar(produto);
                return Ok(produto);
        }

        [HttpDelete("remover/{id}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult Remover(int id)
        {
            var produto = _repository.BuscarPorId(id);
            if (produto == null)
                return NotFound("Produto não encontrado");

            _repository.Remover(id);
            return Ok("Produto Deletado com sucesso");
        }
    }
}
        