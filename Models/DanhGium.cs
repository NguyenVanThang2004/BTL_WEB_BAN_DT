using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class DanhGium
{
    public string? NoiDung { get; set; }

    public int? Rate { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MaHoaDon { get; set; }

    public virtual HoaDonBan? MaHoaDonNavigation { get; set; }

    public virtual TaiKhoan? TenDangNhapNavigation { get; set; }
}
