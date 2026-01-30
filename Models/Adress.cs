using System;
using System.Collections.Generic;

namespace ProjectPP.Models;

public partial class Adress
{
    public int Id { get; set; }

    public byte[] Street { get; set; } = null!;

    public byte[] NumberOfPlace { get; set; } = null!;

    public byte[] Neighborhood { get; set; } = null!;

    public byte[] City { get; set; } = null!;

    public byte[] Country { get; set; } = null!;

    public byte[] Routes { get; set; } = null!;
}
