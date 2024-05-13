using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Khuyenmai
{
    public int Makm { get; set; }

    public double? Phantramkm { get; set; }

    public string? Tenkm { get; set; }

    public string? Dk { get; set; }

    public virtual ICollection<Phieudattour> Phieudattours { get; set; } = new List<Phieudattour>();
}
