using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Hinhanh
{
    public int Mah { get; set; }

    public int Madd { get; set; }

    public string? UrlHa { get; set; }

    public virtual Diemden MaddNavigation { get; set; } = null!;
}
