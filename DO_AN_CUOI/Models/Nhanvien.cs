using System;
using System.Collections.Generic;

namespace DO_AN_CUOI.Models;

public partial class Nhanvien
{
    public int Manv { get; set; }

    public string? Tennv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Sdt { get; set; }

    public string? Dc { get; set; }

    public virtual ICollection<Phieudattour> Phieudattours { get; set; } = new List<Phieudattour>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
