using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
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
            FilmMediainfo UtilityClass = new()
            {
                Actors = _ctx.Actors?.OrderBy(x => x.Name).ToList()!,
                Features = _ctx.Features?.OrderBy(x => x.Id).ToList()!,
                Genres = _ctx.Genres?.OrderBy(x => x.Id).ToList()!
            };

            return View(UtilityClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmMediainfo formdata)
        {
            //Duration Description VisualizationCount -- Year IsNew FilmId

            if (!ModelState.IsValid)
            {
                formdata.Actors = _ctx.Actors?.OrderBy(x => x.Name).ToList()!;
                formdata.Features = _ctx.Features?.OrderBy(x => x.Id).ToList()!;
                formdata.Genres = _ctx.Genres?.OrderBy(x => x.Id).ToList()!;

                return View(formdata);
            }

            formdata.Film.Duration = 0;
            formdata.Film.MediaInfo.IsNew = true;
            formdata.Film.MediaInfo.Cast =
                _ctx.Actors?
                .Where(act => formdata.ActorIds
                .Contains(act.Id)).ToList()!;

            formdata.Film.MediaInfo.Genres =
                _ctx.Genres?
                .Where(g => formdata.GenreIds
                .Contains(g.Id)).ToList()!;

            formdata.Film.MediaInfo.Features =
                _ctx.Features?
                .Where(feat => formdata.FeatureIds
                .Contains(feat.Id)).ToList()!;


            _ctx.Films?.Add(formdata.Film);
            _ctx.MediaInfos?.Add(formdata.Film.MediaInfo);
            _ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            Film film = _ctx.Films.Include("MediaInfo").Where(f => f.Id == id).First();
            MediaInfo mediaInfo = _ctx.MediaInfos.Include("Cast").Include("Genres").Include("Features").Where(m => m.FilmId == id).First();

            if (film is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {
                FilmMediainfo UtilityClass = new()
                {
                    Film = film,
                    Actors = _ctx.Actors.ToList(),
                    Genres = _ctx.Genres.ToList(),
                    Features = _ctx.Features.ToList(),
                };

                return View(UtilityClass);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FilmMediainfo formdata)
        {
            formdata.Film.Id = id;

            //if (!ModelState.IsValid)
            //{
            //    return View(actor);
            //}
            //_ctx.Actors.Update(actor);
            //_ctx.SaveChanges();
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
