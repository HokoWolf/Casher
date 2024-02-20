using Casher.Areas.User.Models;
using Casher.Dal.EfStructures;
using Casher.Exceptions;
using Casher.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Casher.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class HomeController(DataManager dataManager) : Controller
    {
        private readonly DataManager _dataManager = dataManager;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            var cardNumber = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (cardNumber != null)
            {
                var account = await _dataManager.Accounts.FindByCardNumberAsync(cardNumber);

                if (account != null)
                {
                    Operation operation = new()
                    {
                        BankAccountId = account.Id,
                        OperationTypeId = 1,
                        OperationDateTime = DateTime.UtcNow
                    };

                    _dataManager.Operations.Add(operation);

                    return View(new BalanceViewModel
                    {
                        CardNumber = account.ViewCardNumber,
                        Date = operation.OperationDateTime.ToString("dd/MM/yyyy"),
                        Balance = account.AccountBalance
                    });
                }
            }

            return RedirectToAction("Logout", "Home");
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            return View(new WithdrawViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(WithdrawViewModel model)
        {
            if (model.MoneyAmount == null)
            {
                throw new NullMoneyAmountException("Please, enter money amount you want to withdraw");
            }

            var cardNumber = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (cardNumber != null)
            {
                var account = await _dataManager.Accounts.FindByCardNumberAsync(cardNumber);

                if (account != null)
                {
                    try
                    {
                        account.AccountBalance -= model.MoneyAmount.Value;

                        _dataManager.Accounts.Update(account);

                        Operation operation = new()
                        {
                            BankAccountId = account.Id,
                            OperationTypeId = 1,
                            OperationDateTime = DateTime.UtcNow,
                            MoneyAmount = model.MoneyAmount
                        };
                        _dataManager.Operations.Add(operation);

                        model.CardNumber = account.ViewCardNumber;
                        model.Date = operation.OperationDateTime.ToString("dd/MM/yyyy");
                        model.Time = operation.OperationDateTime.ToString("HH:mm:ss");
                        model.Balance = account.AccountBalance;

                        return View("WithdrawReport", model);
                    }
                    catch (DbUpdateException ex)
                    {
                        throw new NotEnoughMoneyException($"{ex.Message} Not enough money for this operation");
                    }
                }
            }

            return RedirectToAction("Logout", "Home");
        }

        [HttpGet]
        public IActionResult WithdrawReport()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
