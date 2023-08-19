using CodingWiki_DataAccess.Data;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _context;
        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {

            Category category = new();
            if (id == null || id == 0)
            {
                return View(category);
            }
            category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    await _context.AddAsync(category);
                }
                else
                {
                    _context.Categories.Update(category);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }

        public IActionResult Delete(int? id)
        {
            Category category = new();
            category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            for(int i = 1; i <=2; i++)
            {
                _context.Categories.Add(new Category() { Name = Guid.NewGuid().ToString() });
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            for(int i = 1; i <=5; i++)
            {
                _context.Categories.Add(new Category() { Name = Guid.NewGuid().ToString() });
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> categories = _context.Categories.OrderBy(c => c.CategoryId).Take(2);
            _context.RemoveRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> categories = _context.Categories.OrderBy(c => c.CategoryId).Take(5);
            _context.RemoveRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
