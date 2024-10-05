using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shopping.Models;
using Shopping.Models.ViewModels;
using System.Linq.Expressions;

namespace Shopping.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<AppUserModel> _userManage;
		private SignInManager<AppUserModel> _signInManager;

		public AccountController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userManage)
		{
			_signInManager = signInManager;
			_userManage = userManage;
		}

		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel { ReturnUrl = returnUrl });
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (ModelState.IsValid)
			{
				Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.Username, loginVM.Password, false, false);
				if (result.Succeeded)
				{
					return Redirect(loginVM.ReturnUrl ?? "/");
				}
				ModelState.AddModelError("", "Username hoặc Password bị sai");
			}
			return View(loginVM);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Create(UserModel user)
		{
			if (ModelState.IsValid)
			{
				AppUserModel newUser = new AppUserModel { UserName = user.Username, Email = user.Email };
				IdentityResult result = await _userManage.CreateAsync(newUser, user.Password);
				if (result.Succeeded)
				{
					TempData["success"] = "Tạo tài khoản thành công";
					return Redirect("/account/login");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(user);
		}

		public async Task<IActionResult> Logout (string returnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}
	}

}
