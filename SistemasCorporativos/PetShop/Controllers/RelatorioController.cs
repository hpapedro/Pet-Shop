using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;

[ApiController]
[Route("api/relatorios")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioRepository _repository;

    public RelatorioController(IRelatorioRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("total-entradas")]
    public IActionResult TotalEntradas()
    {
        var resultado = _repository.ObterTotalEntradas();
        return Ok(resultado);
    }

    [HttpGet("total-saidas")]
    public IActionResult TotalSaidas()
    {
        var resultado = _repository.ObterTotalSaidas();
        return Ok(resultado);
    }
}
