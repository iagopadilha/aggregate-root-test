using System;
using System.Collections.Generic;

namespace ProjectPP.Models;

public partial class AtributoProduto
{
    public int Id { get; set; }

    public int ProdutoAgregadoId { get; set; }

    public string NomeAtributo { get; set; } = null!;

    public virtual ProdutoAgregado ProdutoAgregado { get; set; } = null!;
}
