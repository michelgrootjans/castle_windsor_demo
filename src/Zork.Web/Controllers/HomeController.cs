using System.Web.Mvc;
using Zork.Core.Players;

namespace Zork.Web.Controllers
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
