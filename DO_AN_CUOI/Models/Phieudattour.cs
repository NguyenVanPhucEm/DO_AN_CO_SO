using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Phieudattour
{
    public int Mapdt { get; set; }

    public int Matour { get; set; }

    public int Makh { get; set; }

    public int Makm { get; set; }

    public int Manv { get; set; }

    public int? Song { get; set; }

    public DateTime? Ngaydat { get; set; }

    public int? Tongtien { get; set; }

    public string? Dvt { get; set; }

    public virtual Khachhang MakhNavigation { get; set; } = null!;

    public virtual Khuyenmai MakmNavigation { get; set; } = null!;

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual Tour MatourNavigation { get; set; } = null!;
}
