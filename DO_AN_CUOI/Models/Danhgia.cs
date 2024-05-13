using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Danhgia
{
    public int Makh { get; set; }

    public int Matour { get; set; }

    public string? Noidungdanhgia { get; set; }

    public int? Sosao { get; set; }

    public DateTime? Thoigiandanhgia { get; set; }

    public virtual Khachhang MakhNavigation { get; set; } = null!;

    public virtual Tour MatourNavigation { get; set; } = null!;
}
