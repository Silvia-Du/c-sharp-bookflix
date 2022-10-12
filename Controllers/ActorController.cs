using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_bookflix.Controllers
{
    public class ActorController : Controller
    {
        readonly BoolflixContext _ctx = new();

        public IActionResult Index()
        {
            List<Actor> actors = _ctx.Actors.ToList();
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _ctx.Actors.Add(actor);
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

            List<Actor> actors = _ctx.Actors.ToList();
            return View("Index", actors);
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
