using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult RedirectToIndexActionInCurrentController()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
