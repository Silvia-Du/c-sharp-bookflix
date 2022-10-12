using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_bookflix.Controllers
{
    public class GenreController : Controller
    {
        readonly BoolflixContext _ctx = new();

        public IActionResult Index()
        {
            List<Genre> genres = _ctx.Genres?.ToList()!;
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _ctx.Genres?.Add(genre);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Genre? genre = _ctx.Genres?.FirstOrDefault(x => x.Id == id);

            if (genre is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Genre genre)
        {
            genre.Id = id;

            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            _ctx.Genres?.Update(genre);
            _ctx.SaveChanges();

            List<Genre> genres = _ctx.Genres?.ToList()!;
            return View("Index", genres);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Genre? genre = _ctx.Genres?.FirstOrDefault(x => x.Id == id);

            if (genre is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            _ctx.Genres?.Remove(genre);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}
