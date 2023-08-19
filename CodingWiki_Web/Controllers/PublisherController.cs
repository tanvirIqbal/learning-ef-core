using CodingWiki_DataAccess.Data;
using CodingWiki_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDBContext _context;
        public PublisherController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Publisher> publishers = _context.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {

            Publisher publisher = new();
            if (id == null || id == 0)
            {
                return View(publisher);
            }
            publisher = _context.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.Publisher_Id == 0)
                {
                    await _context.AddAsync(publisher);
                }
                else
                {
                    _context.Publishers.Update(publisher);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(publisher);
            }
        }

        public IActionResult Delete(int? id)
        {
            Publisher publisher = new();
            publisher = _context.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
