using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        //the route is needed to make sure that the parameter name is the same
        //if not the same, the value will not be passed (0)
        [Route("Home/StatusError/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            ViewBag.ErrorCode = statusCode;
            return View();
        }
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View();
        }
        public void Exception()
        {
            throw new System.Exception("Random exception thrown...");
        }

    }
}
