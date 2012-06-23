using System.Web.Mvc;
using Zork.Core;

namespace Zork.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var dto = new GetCharacterInfoQueryHandler().GetCharacterOf(User.Identity.Name);
            return View(dto);
        }

        [HttpPost]
        public ActionResult Choose(UserChoiceCommand command)
        {
            return RedirectToAction("Index");
        }
    }
}
