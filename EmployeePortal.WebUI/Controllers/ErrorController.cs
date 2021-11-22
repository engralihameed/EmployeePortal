using EmployeePortal.Core.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILog _log;
        public ErrorController()
        {
            _log = Log.GetInstance;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            // Retrieve the exception Details
            var statusCodeResult =
                    HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.ErrorMessage = "Sorry, the resource you are looking for couldn't be found";
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;


            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            _log.LogException(exceptionHandlerPathFeature.Error.Message);
            
            //ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            //ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            //ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");
        }
    }
}
