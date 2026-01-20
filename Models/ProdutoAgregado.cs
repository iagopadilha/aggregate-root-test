using System;
using System.Collections.Generic;

namespace ProjectPP.Models;

public partial class ProdutoAgregado
{
    public int Id { get; set; }

    public string NomeProduto { get; set; } = null!;

    public decimal QuantidadeProduto { get; set; }

    public virtual ICollection<AtributoProduto> AtributoProdutos { get; set; } = new List<AtributoProduto>();
}
