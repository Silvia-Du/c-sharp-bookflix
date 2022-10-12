using c_sharp_bookflix.Models;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_bookflix.Controllers
{
    public class EditorController : Controller
    {
        readonly BoolflixContext _ctx = new();
        //public EditorController(BoolflixContext ctx)
        //{
        //    _ctx = ctx;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Episode()
        {
            return View();
        }


    }
}
