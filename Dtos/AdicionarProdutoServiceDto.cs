
using ProjectPP.Dtos;

public class AdicionarProdutoServiceDto
{
    public string NomeProduto { get; set; }
    public decimal QuantidadeProduto { get; set; }
    public List<AdicionarAtributoProdutoDto> AdicionarAtributoProdutoDto { get; set; }
}
