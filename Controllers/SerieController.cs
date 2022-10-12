using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_bookflix.Controllers
{

    // id titolo durata descrizione visualizzazione-count season-count ..media info
    public class SerieController : Controller
    {
        readonly BoolflixContext _ctx = new();

        public IActionResult Index()
        {
            List<TvSerie> series = _ctx.Series?.OrderBy(serie => serie.Id).ToList()!;
            return View(series);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    _ctx.Actors.Add(actor);
        //    _ctx.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult Update(int id)
        //{
        //    Actor? actor = _ctx.Actors.FirstOrDefault(x => x.Id == id);

        //    if (actor is null)
        //    {
        //        return NotFound("Non è stata trovata nessuna corrispondenza");
        //    }
        //    return View(actor);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(int id, Actor actor)
        //{
        //    actor.Id = id;

        //    if (!ModelState.IsValid)
        //    {
        //        return View(actor);
        //    }
        //    _ctx.Actors.Update(actor);
        //    _ctx.SaveChanges();
        //    return RedirectToAction(nameof(Index));

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id)
        //{

        //    Actor? actor = _ctx.Actors?.FirstOrDefault(x => x.Id == id);

        //    if (actor is null)
        //    {
        //        return NotFound("Non è stata trovata nessuna corrispondenza");
        //    }

        //    _ctx.Actors?.Remove(actor);
        //    _ctx.SaveChanges();
        //    return RedirectToAction(nameof(Index));

        //}


    }
}
