using System;
using System.Collections.Generic;

namespace BTL_WEB_BAN_DT.Models;

public partial class AnhSanPham
{
    public string TenFile { get; set; } = null!;

    public string? ViTri { get; set; }

    public string? MaSanPham { get; set; }
}
