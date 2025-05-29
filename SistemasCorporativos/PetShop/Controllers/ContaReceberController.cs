using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;

[ApiController]
[Route("api/contasReceber")]
public class ContaReceberController : ControllerBase
{
    private readonly IContaReceberRepository _repo;

    public ContaReceberController(IContaReceberRepository repo)
    {
        _repo = repo;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] ContaReceber conta)
    {
        _repo.Adicionar(conta);
        return Ok("Conta a receber cadastrada.");
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        var contas = _repo.Listar();
        return Ok(contas);
    }

    [HttpPut("receber/{id}")]
    public IActionResult Receber(int id)
    {
        _repo.Receber(id);
        return Ok("Conta marcada como recebida.");
    }
}
