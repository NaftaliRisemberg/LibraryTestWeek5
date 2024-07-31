using LibraryTestWeek5.DAL;
using LibraryTestWeek5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryTestWeek5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Library()
        {
            List<Library> library = Data.Get.libraries.ToList();
            return View(library);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Library library)
        {
            Data.Get.libraries.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }
        
        public IActionResult AddShelf() 
        { 
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(Shelf shelf)
        {
            Data.Get.shelves.Add(shelf);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
