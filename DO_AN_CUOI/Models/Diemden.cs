using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Diemden
{
    public int Madd { get; set; }

    public string Tendd { get; set; } = null!;

    public string? Dc { get; set; }

    public string? Thongtindiemden { get; set; }

    public virtual ICollection<Hinhanh> Hinhanhs { get; set; } = new List<Hinhanh>();

    public virtual ICollection<Lichtrinh> Lichtrinhs { get; set; } = new List<Lichtrinh>();
}
