using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Casher.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.path = exceptionDetails?.Path;
            ViewBag.errorMessage = exceptionDetails?.Error?.Message;
            return View();
        }
    }
}
