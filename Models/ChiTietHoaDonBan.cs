using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class ChiTietHoaDonBan
{
    public int? SoLuongBan { get; set; }

    public decimal? DonGiaCuoi { get; set; }

    public string? MaHoaDon { get; set; }

    public string? MaSanPham { get; set; }

    public virtual HoaDonBan? MaHoaDonNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
