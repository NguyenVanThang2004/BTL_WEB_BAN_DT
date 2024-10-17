﻿using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class TaiKhoan
{
    public string TenDangNhap { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string? LoaiTaiKhoan { get; set; }

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<LichSuHoatDong> LichSuHoatDongs { get; set; } = new List<LichSuHoatDong>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
