using System.Web.Mvc;
using zork.core.Players;

namespace zork.web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var dto = new GetPlayerInfoQueryHandler().HandleQuery();
            return View(dto);
        }
    }
}
