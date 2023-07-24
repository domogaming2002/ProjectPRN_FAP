using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using System.Security.Claims;

namespace ProjectPRN_FAP.Pages.Common
{
    public class LoginModel : PageModel
    {
        private IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public LoginDTO loginDTO { get; set; }
        public bool IsLoginFailed { get; set; } = false;
        public  IActionResult OnGet()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                if (claimUser.FindFirstValue(ClaimTypes.Role) == "1")
                {
                    return RedirectToPage("/Admin/SemesterPage/Semester");
                }
                else if (claimUser.FindFirstValue(ClaimTypes.Role) == "2")
                {
                    return RedirectToPage("/Teacher/ClassPage/ListClass");
                }
                else
                {
                    return RedirectToPage("/Student/Index");
                }
            }
            return Page();
        }

       


        public async Task<IActionResult> OnPost(LoginDTO loginDTO) 
        {
            UserDTO loginAccount = _userRepository.GetUserLogin(loginDTO);
            if (loginAccount != null)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, loginDTO.Email),
                new Claim(ClaimTypes.Role, loginAccount.RoleId.ToString()),
                new Claim(ClaimTypes.Sid, loginAccount.UserId.ToString())
            };

                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = loginDTO.RememberMe
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                if (loginAccount.RoleId == 1)
                   return RedirectToPage("/Admin/SemesterPage/Semester");
                else if (loginAccount.RoleId == 2)
                    return RedirectToPage("/Teacher/ClassPage/ListClass");
                else
                    return RedirectToPage("/Admin/SemesterPage/Semester");
            }

            IsLoginFailed = true;
            return RedirectToPage("/Common/Login");
        }

        public async Task<IActionResult> OnPostLogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Common/Login");
        }

    }
}
