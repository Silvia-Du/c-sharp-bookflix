using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_bookflix.Controllers
{
    public class FilmController : Controller
    {
        readonly BoolflixContext _ctx = new();

        public IActionResult Index()
        {
            
            List<Film> films = _ctx.Films?.Include("MediaInfo").OrderBy(x => x.Id).ToList()!;
            return View(films);
        }

        public IActionResult Create()
        {
            FilmMediainfo UtilityClass = new();
            UtilityClass.Actors = _ctx.Actors?.OrderBy(x => x.Name).ToList()!;
            UtilityClass.Features = _ctx.Features?.OrderBy(x => x.Id).ToList()!;
            UtilityClass.Genres = _ctx.Genres?.OrderBy(x => x.Id).ToList()!;

            return View(UtilityClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmMediainfo utilityClass)
        {
            //Duration Description VisualizationCount -- Year IsNew FilmId

            if (!ModelState.IsValid)
            {
                utilityClass.Actors = _ctx.Actors?.OrderBy(x => x.Name).ToList()!;
                utilityClass.Features = _ctx.Features?.OrderBy(x => x.Id).ToList()!;
                utilityClass.Genres = _ctx.Genres?.OrderBy(x => x.Id).ToList()!;

                return View(utilityClass);
            }

            utilityClass.Film.Duration = 0;
                _ctx.Ingredients?
                .Where(ing => utilityClass.IngredientIds
                .Contains(ing.Id)).ToList();

            _ctx.Pizzas?.Add(utilityClass.Pizza);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Actor? actor = _ctx.Actors.FirstOrDefault(x => x.Id == id);

            if (actor is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,Actor actor)
        {
            actor.Id = id;

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _ctx.Actors.Update(actor);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Actor? actor = _ctx.Actors?.FirstOrDefault(x => x.Id == id);

            if (actor is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            _ctx.Actors?.Remove(actor);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}
