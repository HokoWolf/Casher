using Casher.Dal.EfStructures;
using Casher.Exceptions;
using Casher.Models;
using Casher.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Casher.Controllers
{
    public class AccountController(DataManager dataManager) : Controller
	{
		private readonly DataManager _dataManager = dataManager;

		[HttpGet]
		public IActionResult Login()
		{
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
		}

		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
                var cardNumber = model?.CardNumber?.Replace("-", "");
                var account = await _dataManager.Accounts.FindByCardNumberAsync(cardNumber);

                if (account != null)
				{
                    if (!account.IsBlocked)
                    {
                        TempData["CardNumber"] = cardNumber;
                        return RedirectToAction("PinCode", "Account");
                    }

                    throw new BlockedCardException("This Account was blocked due to 4th incorrect authentication attempt");
                }

                throw new InvalidCardNumberException("Account with this card number is not existing");
            }

            throw new InvalidCardNumberException("Account with this card number is not existing");
        }

        [HttpGet]
        public IActionResult PinCode()
		{
            var cardNumber = TempData["CardNumber"] as string;

            if (!string.IsNullOrEmpty(cardNumber))
            {
                TempData["CardNumber"] = cardNumber;
                return View(new PinCodeViewModel());
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> PinCode(PinCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cardNumber = TempData["CardNumber"] as string; 
                var account = await _dataManager.Accounts.FindByCardNumberAsync(cardNumber!);

                PinCodeAttempt pinCodeAttempt = new()
                {
                    BankAccountId = account!.Id,
                    AttemptDateTime = DateTime.Now
                };

                if (account.PinCode.Equals(model.PinCode, StringComparison.OrdinalIgnoreCase))
                {
                    pinCodeAttempt.IsSuccessful = true;
                    _dataManager.PinCodeAttempts.Add(pinCodeAttempt);
                    
                    List<Claim> claims =
                    [
                        new Claim(ClaimTypes.NameIdentifier, cardNumber!)
                    ];

                    ClaimsIdentity claimsIdentity = new(claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new()
                    {
                        AllowRefresh = true,
                        IsPersistent = false
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    pinCodeAttempt.IsSuccessful = false;
                    await _dataManager.PinCodeAttempts.AddAsync(pinCodeAttempt);

                    var count = await _dataManager.PinCodeAttempts
                        .GetUnsuccessfulAttemptsCountAsync(account);

                    if (count > 3)
                    {
                        account.IsBlocked = true;
                        _dataManager.Accounts.Update(account);
                        throw new BlockedCardException("This Account was blocked due to 4th incorrect authentication attempt");
                    }

                    TempData["CardNumber"] = cardNumber;
                    throw new IncorrectPinCodeException("Pin Code for this account is incorrect");
                }
            }

            throw new IncorrectPinCodeException("Pin Code for this account is incorrect");
        }
	}
}
