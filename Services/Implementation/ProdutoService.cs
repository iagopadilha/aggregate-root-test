using Microsoft.EntityFrameworkCore;
using ProjectPP.Data;
using ProjectPP.Models;
using ProjectPP.Services.Interfaces;

namespace ProjectPP.Services.Implementation;

public class ProdutoService : IProdutoService
{
    private readonly MydatabaseContext Db;

    public ProdutoService(MydatabaseContext databaseContext)
    {
        Db = databaseContext;
    }

    public async Task AdicionarProdutoAgregado(AdicionarProdutoServiceDto adicionarAtributoProdutoDto)
    {
        var produto = new ProdutoAgregado
        {
            NomeProduto = adicionarAtributoProdutoDto.NomeProduto,
            QuantidadeProduto = adicionarAtributoProdutoDto.QuantidadeProduto,
            AtributoProdutos = adicionarAtributoProdutoDto.AdicionarAtributoProdutoDto?.Select(dto => new AtributoProduto
            {
                NomeAtributo = dto.NomeAtributo
            }).ToList() ?? new List<AtributoProduto>()
        };

        Db.ProdutoAgregados.Add(produto);

        await Db.SaveChangesAsync();
    }

    public async Task AtualizarProdutoAgregado(AtualizarProdutoServiceDto atualizarProdutoServiceDto)
    {
        var produto = await Db.ProdutoAgregados
            .Include(p => p.AtributoProdutos)
            .FirstOrDefaultAsync(p => p.Id == atualizarProdutoServiceDto.Id);

        if (produto == null)
        {
            throw new Exception($"Produto com ID {atualizarProdutoServiceDto.Id} não encontrado.");
        }

        produto.NomeProduto = atualizarProdutoServiceDto.NomeProduto;
        produto.QuantidadeProduto = atualizarProdutoServiceDto.QuantidadeProduto;

        var atributosExistentesIds = produto.AtributoProdutos.Select(a => a.Id).ToList();
        var atributosNovosIds = atualizarProdutoServiceDto.AtualizarAtributoProdutoDto?.Select(a => a.Id).ToList() ?? new List<int>();

        var atributosParaRemover = produto.AtributoProdutos
            .Where(a => !atributosNovosIds.Contains(a.Id))
            .ToList();

        foreach (var atributo in atributosParaRemover)
        {
            Db.AtributoProdutos.Remove(atributo);
        }

        if (atualizarProdutoServiceDto.AtualizarAtributoProdutoDto != null)
        {
            foreach (var atributoDto in atualizarProdutoServiceDto.AtualizarAtributoProdutoDto)
            {
                if (atributoDto.Id == 0)
                {
                    produto.AtributoProdutos.Add(new AtributoProduto
                    {
                        NomeAtributo = atributoDto.NomeAtributo,
                        ProdutoAgregadoId = produto.Id
                    });
                }
                else
                {
                    var atributoExistente = produto.AtributoProdutos.FirstOrDefault(a => a.Id == atributoDto.Id);
                    if (atributoExistente != null)
                    {
                        atributoExistente.NomeAtributo = atributoDto.NomeAtributo;
                    }
                }
            }
        }

        Db.ProdutoAgregados.Update(produto);
        await Db.SaveChangesAsync();
    }
}
