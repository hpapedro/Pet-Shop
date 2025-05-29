using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;

[ApiController]
[Route("api/contasPagar")]

public class ContaPagarController : ControllerBase
{
    private readonly IContaPagarRepository _repository;

    public ContaPagarController(IContaPagarRepository repository)
    {
        _repository = repository;
    }
    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(ContaPagar conta)
    {
        _repository.Adicionar(conta);
        return Ok(conta);
    }
    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_repository.Listar());
    }
    [HttpPut("pagar/{id}")]
    public IActionResult Pagar(int id)
    {
        var conta = _repository.BuscarPorId(id);
        if (conta is null) return NotFound();

        conta.Pago = true;
        _repository.Atualizar(conta);
        return Ok(conta);
    }
}