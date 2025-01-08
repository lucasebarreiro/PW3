using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW3.Application.Interfaces.Services;

namespace PW3.Presentation.Pages
{
    public class LoginModel(IUserService _userService, ITokenService _tokenService) : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public string? Token { get; private set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (await _userService.ValidateUserAsync(Username, Password))
            {
                Token = _tokenService.GenerateToken(Username);
                return RedirectToPage("Index");
            }

            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            return Page();
        }
    }
}