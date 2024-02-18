using Casher.Models;
using Microsoft.AspNetCore.Mvc;

namespace Casher.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Balance()
		{
			return View();
		}

        public IActionResult Withdraw()
        {
			return View(new WithdrawViewModel());
        }

        public IActionResult WithdrawReport()
        {
            return View();
        }
    }
}
