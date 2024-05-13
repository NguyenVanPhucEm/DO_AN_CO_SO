using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Khachhang
{
    public int Makh { get; set; }

    public string? Tenkh { get; set; }

    public string? Sdt { get; set; }

    public string? Dc { get; set; }

    public int? Sotourdadat { get; set; }

    public virtual ICollection<Danhgia> Danhgia { get; set; } = new List<Danhgia>();

    public virtual ICollection<Phieudattour> Phieudattours { get; set; } = new List<Phieudattour>();
}
