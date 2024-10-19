using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using BTL_WEB_BAN_DT.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_WEB_BAN_DT.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        BtlLtwQlbdtContext db=new BtlLtwQlbdtContext(); 
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSanPham);
            PagedList<SanPham> lst = new PagedList<SanPham>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
    }

}
