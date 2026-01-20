using ProjectPP.Dtos;

public class AtualizarProdutoServiceDto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; }
    public decimal QuantidadeProduto { get; set; }
    public List<AtualizarAtributoProdutoDto> AtualizarAtributoProdutoDto { get; set; }
}
