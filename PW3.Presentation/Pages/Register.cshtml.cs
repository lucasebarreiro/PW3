using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW3.Application.Interfaces;

namespace PW3.Presentation.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _userService.RegisterUserAsync(Username, Password))
                return RedirectToPage("Login");

            ModelState.AddModelError(string.Empty, "El usuario ya existe.");
            return Page();
        }
    }
}