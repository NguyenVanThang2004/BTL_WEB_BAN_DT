﻿using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class HoaDonBan
{
    public string MaHoaDon { get; set; } = null!;

    public string? PhuongThucThanhToan { get; set; }

    public decimal? TongTien { get; set; }

    public decimal? KhuyenMai { get; set; }

    public DateTime? ThoiGianLap { get; set; }

    public string? MaNhanVien { get; set; }

    public string? MaKhachHang { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
