using System.Web.Mvc;
using Zork.Core;
using Zork.Core.Characters;

namespace Zork.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var character = new GetCharacterInfoQueryHandler().GetCharacterOf(User.Identity.Name);
            if(character == null)
                return RedirectToAction("NewCharacter");
            if (!character.IsAlive)
                return RedirectToAction("YouAreDead");
            
            return View(character);
        }

        [HttpGet]
        public ActionResult NewCharacter()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YouAreDead()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCharacter(CreateCharacterCommand command)
        {
            command.UserName = User.Identity.Name;
            ICreateCharacterHandler handler = new CreateCharacterHandler();
            handler.Execute(command);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Choose(UserChoiceCommand command)
        {
            IUserChoiceHandler handler = new UserChoiceHandler();
            handler.Execute(command);
            return RedirectToAction("Index");
        }
    }
}
