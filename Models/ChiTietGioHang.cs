using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class ChiTietGioHang
{
    public int? SoLuong { get; set; }

    public string? MaGioHang { get; set; }

    public string? MaSanPham { get; set; }

    public virtual GioHang? MaGioHangNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
