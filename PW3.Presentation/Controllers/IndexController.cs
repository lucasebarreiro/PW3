using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PW3.Presentation.Hubs;
using PW3.Presentation.ViewModels;

namespace PW3.Presentation.Controllers
{
    public class IndexController : Controller
    {
        public IndexController()
        {
            ViewData["Title"] = "Lobby";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new CreateGameViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateGameViewModel model, IHubContext<GameHub> hubContext, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Ingresa un nombre no gay";
                return View(model);
            }
            var newGuid = Guid.NewGuid();
            var gameId = Convert.ToBase64String(newGuid.ToByteArray())[..22];
            ViewBag.Id = gameId;
            await hubContext.Groups.AddToGroupAsync(HttpContext.Connection.Id, $"game-{gameId}", ct);
            await hubContext.Clients.Group($"game-{gameId}").SendAsync("", ct);
            return View("Game");
        }
    }
}
