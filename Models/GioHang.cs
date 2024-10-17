using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class GioHang
{
    public string MaGioHang { get; set; } = null!;

    public decimal? TongTien { get; set; }

    public string? TenDangNhap { get; set; }

    public virtual TaiKhoan? TenDangNhapNavigation { get; set; }
}
