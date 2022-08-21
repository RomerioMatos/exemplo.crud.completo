using Microsoft.AspNetCore.Mvc;
using exemplo.crud.core.interfaces;
using exemplo.crud.core.agregados;
using exemplo.crud.core.servicos;
using exemplo.crud.web.models;

namespace exemplo.crud.web.controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly ILogger<ProdutoController> _logger;
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IProdutoServico _produtoServico;

    public ProdutoController(ILogger<ProdutoController> logger, IProdutoRepositorio produtoRepositorio)
    {
        _logger = logger;
        _produtoRepositorio = produtoRepositorio;
        _produtoServico = new ProdutoServico(produtoRepositorio);
    }

    [HttpGet("{id:guid}", Name = "Get")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var produto = await _produtoServico.ObterId(id.ToString());

        if (produto == null)
        {
            return NotFound();
        }

        var retorno = new ProdutoModel
        {
            Id = produto.Id,
            Descricao = produto.Descricao,
            Unidade = produto.Unidade,
            Preco = produto.Preco
        };

        return Ok(retorno);
    }

    [HttpPost(Name = "Post")]
    public async Task<IActionResult> Post([FromBody] ProdutoModel obj)
    {
        if (obj == null)
        {
            return BadRequest();
        }

        var produto = new Produto()
        {
            Id = Guid.NewGuid().ToString(),
            Descricao = obj.Descricao,
            Unidade = obj.Unidade,
            Preco = obj.Preco,
            Ativo = true,
            UsuarioInclusao = "web",
            DataInclusao = DateTime.Now
        };

        var retorno = await _produtoServico.Novo(produto);

        return CreatedAtRoute("Get", new { id = retorno.Id }, new ProdutoModel(){
            Id = retorno.Id,
            Descricao = retorno.Descricao,
            Unidade = retorno.Unidade,
            Preco = retorno.Preco
        });
    }

    [HttpPut(Name = "Put")]
    public async Task<IActionResult> Put([FromBody] ProdutoModel obj)
    {
        if (obj == null)
        {
            return BadRequest();
        }

        var produto = await _produtoServico.ObterId(obj.Id);

        if (produto == null)
        {
            return NotFound();
        }

        produto.Descricao = obj.Descricao;
        produto.Unidade = obj.Unidade;
        produto.Preco = obj.Preco;

        var sucesso = await _produtoServico.Alterar(produto);

        if (!sucesso)
        {
            return NotFound();
        }

        return Ok(obj);
    }

    [HttpDelete("{id:guid}", Name = "Delete")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var sucesso = await _produtoServico.Remover(id.ToString());

        if (!sucesso)
        {
            return NotFound();
        }

        return Ok();
    }
}
