using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW3.Application.Interfaces;

namespace PW3.Presentation.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _userService.ValidateUserAsync(Username, Password))
                return RedirectToPage("Index");

            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            return Page();
        }
    }
}