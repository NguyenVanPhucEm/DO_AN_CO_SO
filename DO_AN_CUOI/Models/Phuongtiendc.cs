using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Phuongtiendc
{
    public int Mapt { get; set; }

    public string? Tenpt { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
