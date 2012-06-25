using System.Web.Mvc;
using Zork.Core;
using Zork.Core.Api;
using Zork.Core.Characters;

namespace Zork.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GetCharacterInfoQueryHandler characterInfo;
        private readonly ICreateCharacterHandler createCharacter;
        private readonly IUserChoiceHandler choiceHandler;

        public HomeController()
        {
            characterInfo = new GetCharacterInfoQueryHandler();
            createCharacter = new CreateCharacterHandler();
            choiceHandler = new UserChoiceHandler();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var character = characterInfo.GetCharacterOf(User.Identity.Name);
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
            createCharacter.Execute(command);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Choose(UserChoiceCommand command)
        {
            command.UserName = User.Identity.Name;
            choiceHandler.Execute(command);
            return RedirectToAction("Index");
        }
    }
}
