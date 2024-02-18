using Casher.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Casher.Controllers
{
	public class AccountController : Controller
	{
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}

		public IActionResult PinCode()
		{
			return View();
		}
	}
}
