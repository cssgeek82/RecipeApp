using Microsoft.AspNetCore.Mvc;

namespace RecipeApp.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ContainerClass = "pagecontainer";
            return View();
        }

        [Route("produkter")]
        public IActionResult Products()
        {
            ViewBag.ContainerClass = "pagecontainer";
            return View();
        }

        [Route("aterforsaljare")]
        public IActionResult Retailers()
        {
            ViewBag.ContainerClass = "pagecontainer";
            return View();
        }
    }

}
