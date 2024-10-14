using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB_BAN_DT.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        


        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
