using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Post
        public async Task<IActionResult> Index()
        {
            ViewBag.ContainerClass = "pagecontainer";
            return View(await _context.Blogg.OrderByDescending(x => x.CreatedDate).ToListAsync());
        }
        
    }
    
}





