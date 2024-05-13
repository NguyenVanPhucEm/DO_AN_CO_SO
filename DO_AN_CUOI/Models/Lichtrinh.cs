using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Lichtrinh
{
    public int Malt { get; set; }

    public int Maks { get; set; }

    public int Madd { get; set; }

    public int Matour { get; set; }

    public string? Thongtinchitiet { get; set; }

    public virtual Diemden MaddNavigation { get; set; } = null!;

    public virtual Khachsan MaksNavigation { get; set; } = null!;

    public virtual Tour MatourNavigation { get; set; } = null!;
}
