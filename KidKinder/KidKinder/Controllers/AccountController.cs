using AutoMapper;
using KidKinder.Enums;
using KidKinder.Models;
using KidKinder.ViewModels.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers
{
    public class AccountController(UserManager<User> _userManager, SignInManager<User> _signInManager, RoleManager<IdentityRole> _roleManager, IMapper _mapper) : Controller
    {

        private bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;
        public IActionResult Register()
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid) return View();

            User user = new User()
            {
                Fullname = vm.Fullname,
                Email = vm.Email,
                UserName = vm.Username

            };
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return View();
            }
            var resultRole = await _userManager.AddToRoleAsync(user, nameof(Roles.User));
            if (!resultRole.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Login()
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (IsAuthenticated) return RedirectToAction("Index", "Home");
            if (!ModelState.IsValid) return View();

            User? user = null;

            if (vm.UsernameOrEmail.Contains("@"))
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            else
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "Your must confirm your account");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);
            if (!result.Succeeded)
            {
                if(result.IsLockedOut)
                {
                    ModelState.AddModelError("","Wait until" + user.LockoutEnd!.Value.ToString("yyyy-MMM-dd HH:mm:ss"));
                }
                if(result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Username or password is wrong");
                }
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        [Authorize]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
