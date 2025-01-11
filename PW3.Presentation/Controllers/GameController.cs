using Microsoft.AspNetCore.Mvc;

namespace PW3.Presentation.Controllers
{
    public class GameController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
