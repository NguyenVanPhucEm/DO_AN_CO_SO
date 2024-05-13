using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Khachsan
{
    public int Maks { get; set; }

    public string? Tenks { get; set; }

    public string? Dc { get; set; }

    public virtual ICollection<Lichtrinh> Lichtrinhs { get; set; } = new List<Lichtrinh>();
}
