using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Tour
{
    public int Matour { get; set; }

    public int Maloai { get; set; }

    public int Madkh { get; set; }

    public int Manv { get; set; }

    public int Mapt { get; set; }

    public string Tentour { get; set; } = null!;

    public DateTime Ngaykh { get; set; }

    public DateTime? Ngaykt { get; set; }

    public int? Songay { get; set; }

    public int? Sodem { get; set; }

    public int? Soluongtoida { get; set; }

    public int? Sochodadat { get; set; }

    public int? Gia { get; set; }

    public string? Dvt { get; set; }

    public string? AnhAiien { get; set; }

    public virtual ICollection<Danhgia> Danhgia { get; set; } = new List<Danhgia>();

    public virtual ICollection<Lichtrinh> Lichtrinhs { get; set; } = new List<Lichtrinh>();

    public virtual Diemkhoihanh MadkhNavigation { get; set; } = null!;

    public virtual Loaitour MaloaiNavigation { get; set; } = null!;

    public virtual Nhanvien ManvNavigation { get; set; } = null!;

    public virtual Phuongtiendc MaptNavigation { get; set; } = null!;

    public virtual ICollection<Phieudattour> Phieudattours { get; set; } = new List<Phieudattour>();
}
