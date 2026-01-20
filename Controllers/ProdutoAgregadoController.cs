using Microsoft.AspNetCore.Mvc;
using ProjectPP.Services.Interfaces;

namespace ProjectPP.Controllers;

[Route("api/produtos")]
public class ProdutoAgregadoController : ControllerBase
{
    private readonly IProdutoService _produtoAgregadoService;

    public ProdutoAgregadoController(IProdutoService produtoService)
    {
        _produtoAgregadoService = produtoService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> AdicionarProdutoAgregado([FromBody]AdicionarProdutoServiceDto produtoAgregado)
    {
        if (!ModelState.IsValid) return BadRequest("ModelState invalida!");
        await _produtoAgregadoService.AdicionarProdutoAgregado(produtoAgregado);
        return "Produto agregado adicionado com sucesso!";
    }

    [HttpPut]
    public async Task<ActionResult<string>> AtualizarProdutoExistente([FromBody] AtualizarProdutoServiceDto produtoAgregado)
    {
        if (!ModelState.IsValid) return BadRequest("ModelState invalida!");
        
        try
        {
            await _produtoAgregadoService.AtualizarProdutoAgregado(produtoAgregado);
            return "Produto agregado atualizado com sucesso!";
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
