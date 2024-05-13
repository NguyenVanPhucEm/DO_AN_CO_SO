using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Loaitour
{
    public int Maloai { get; set; }

    public string Tenloai { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
