using CodingWiki_DataAccess.Data;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDBContext _context;
        public AuthorController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {

            Author author = new();
            if (id == null || id == 0)
            {
                return View(author);
            }
            author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0)
                {
                    await _context.AddAsync(author);
                }
                else
                {
                    _context.Authors.Update(author);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(author);
            }
        }

        public IActionResult Delete(int? id)
        {
            Author author = new();
            author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
