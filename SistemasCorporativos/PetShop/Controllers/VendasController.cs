using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repositories;
using System.Collections.Generic;


namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;

        public VendasController(IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("cadastrar")]
        public ActionResult<Venda> CadastrarVenda([FromBody] Venda venda)
        {
            if (venda == null || venda.Itens.Count == 0)
                return BadRequest("Venda deve conter ao menos um item");

            decimal valorTotal = 0;

            foreach (var item in venda.Itens)
            {
                var produto = _produtoRepository.BuscarPorId(item.ProdutoId);
                if (produto == null)
                    return BadRequest($"Produto com Id {item.ProdutoId} não encontrado");

                if (produto.QuantidadeEmEstoque < item.Quantidade)
                    return BadRequest($"Estoque insuficiente para o produto {produto.Nome}");

                item.PrecoUnitario = produto.Preco;

                produto.QuantidadeEmEstoque -= item.Quantidade;
                _produtoRepository.Atualizar(produto);

                valorTotal += item.PrecoUnitario * item.Quantidade;
            }

            venda.ValorTotal = valorTotal;
            venda.DataVenda = DateTime.Now;
            venda.Status = StatusVenda.NoCarrinho;

            _vendaRepository.CadastrarVenda(venda);

            return CreatedAtAction(nameof(BuscarPorId), new { id = venda.Id }, venda);
        }

        [HttpGet("{id}")]
        public ActionResult<Venda> BuscarPorId(int id)
        {
            var venda = _vendaRepository.BuscarPorId(id);
            if (venda == null)
                return NotFound("Venda nao encontrada");

            return Ok(venda);
        }

        [HttpGet("Listar")]
        public ActionResult<List<Venda>> ListarTodas()
        {
            return Ok(_vendaRepository.ListarTodas());
        }

        [HttpPut("atualizarStatus/{id}")]
        public ActionResult AtualizarStatus(int id, [FromBody] StatusVenda status)
        {
            var venda = _vendaRepository.BuscarPorId(id);
            if (venda == null)
                return NotFound("Venda não encontrada.");

            venda.Status = status;
            _vendaRepository.AtualizarVenda(venda);

            return Ok("Status atualizado.");
        }

        [HttpGet("notaFiscal/{id}")]
        public ActionResult<string> GerarNotaFiscal(int id)
        {
            var venda = _vendaRepository.BuscarPorId(id);
            if (venda == null)
                return NotFound("Venda não encontrada");
        
            var notaFiscal = new System.Text.StringBuilder();
            notaFiscal.AppendLine($"Nota Fiscal - Venda #{venda.Id}");
            notaFiscal.AppendLine($"Cliente: {venda.ClienteNome ?? "Não informado"}");
            notaFiscal.AppendLine($"Data: {venda.DataVenda}");
            notaFiscal.AppendLine($"Status: {venda.Status}");
            notaFiscal.AppendLine($"Valor Total: R$ {venda.ValorTotal:F2}");
            notaFiscal.AppendLine("\nItens:");
        
            foreach (var item in venda.Itens)
            {
                notaFiscal.AppendLine($"- {item.Produto.Nome} (x{item.Quantidade}) - R$ {item.PrecoUnitario:F2} cada");
            }
        
            return Ok(notaFiscal.ToString());
}


    }
}