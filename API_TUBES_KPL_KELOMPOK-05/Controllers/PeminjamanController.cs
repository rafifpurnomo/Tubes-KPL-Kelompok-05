using Microsoft.AspNetCore.Mvc;

namespace API_TUBES_KPL_KELOMPOK_05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
