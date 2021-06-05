using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Data;
using RecipeApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class BloggController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloggController(ApplicationDbContext context)
        {
            _context = context;
        }

        // /Admin
        [Authorize]
        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }


        // GET: Blogg
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogg.OrderByDescending(x => x.CreatedDate).ToListAsync());
        }

        // .OrderByDescending(x => x.Delivery.SubmissionDate);

        // GET: Blogg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Blogg
                .FirstOrDefaultAsync(m => m.BloggId == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View(blogg);
        }

        // GET: Blogg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogg/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloggId,Author,Title,BloggPost,Category,CreatedDate")] Blogg blogg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogg);
        }

        // GET: Blogg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Blogg.FindAsync(id);
            if (blogg == null)
            {
                return NotFound();
            }
            return View(blogg);
        }

        // POST: Blogg/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloggId,Author,Title,BloggPost,Category,CreatedDate")] Blogg blogg)
        {
            if (id != blogg.BloggId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloggExists(blogg.BloggId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogg);
        }

        // GET: Blogg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Blogg
                .FirstOrDefaultAsync(m => m.BloggId == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View(blogg);
        }

        // POST: Blogg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogg = await _context.Blogg.FindAsync(id);
            _context.Blogg.Remove(blogg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloggExists(int id)
        {
            return _context.Blogg.Any(e => e.BloggId == id);
        }
    }
}
