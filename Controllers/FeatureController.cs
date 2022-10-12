using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_bookflix.Controllers
{
    public class FeatureController : Controller
    {
        readonly BoolflixContext _ctx = new();

        public IActionResult Index()
        {
            List<Feature> features = _ctx.Features.ToList();
            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _ctx.Features.Add(feature);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Feature? feature = _ctx.Features.FirstOrDefault(x => x.Id == id);

            if (feature is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,Feature feature)
        {
            //feature.Id = id;

            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            else

            _ctx.Features.Update(feature);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Feature? feature = _ctx.Features?.FirstOrDefault(x => x.Id == id);

            if (feature is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            
            _ctx.Features?.Remove(feature);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }


    }
}
