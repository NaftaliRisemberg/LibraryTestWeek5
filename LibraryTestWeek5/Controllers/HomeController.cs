using LibraryTestWeek5.DAL;
using LibraryTestWeek5.Models;
using LibraryTestWeek5.viewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult AddShelf(int id)
        {
            ViewBag.id = id;
            return View(new Shelf());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(Shelf shelf)
        {

            Library? firstLirbaryFromDb = Data.Get.libraries.FirstOrDefault(x => x.Id == shelf.LibId);
            if (firstLirbaryFromDb == null)
            {
                return NotFound();
            }
            shelf.Library = firstLirbaryFromDb;

            Shelf newShelf = new Shelf()
            {
                Library = firstLirbaryFromDb,
                Height = shelf.Height,
                Width = shelf.Width,
                Name = shelf.Name,
                LibId = shelf.LibId,
            };

            Data.Get.shelves.Add(newShelf);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }

        public IActionResult Shelves(int id)
        {
            ViewBag.id = id;

            Library? firstLirbaryFromDb = Data.Get.libraries.FirstOrDefault(x => x.Id == id);
            List<Shelf> Shelves = Data.Get.shelves.Where(x => x.Library == firstLirbaryFromDb).ToList();
            return View(Shelves);
        }

        public IActionResult CreateBook()
        {
            viewModelToCreateBook viewModel = new viewModelToCreateBook();
            viewModel.libraries = Data.Get.libraries.ToList();
            viewModel.shelves = Data.Get.shelves.ToList();
            viewModel.book = new Book();
            return View(viewModel);
        }

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult CreateBook(viewModelToCreateBook viewModel)
        {
            Library? firstLirbaryFromDb = Data.Get.libraries.FirstOrDefault(x => x.Id == viewModel.LibId);
            if (firstLirbaryFromDb == null)
            {
                return NotFound();
            }
            viewModel.book.Library = firstLirbaryFromDb;
            
            Shelf? firstShelfFromDb = Data.Get.shelves.FirstOrDefault(x => x.Id == viewModel.ShelfId);
            if (firstShelfFromDb == null)
            {
                return NotFound();
            }
            viewModel.book.Shelf = firstShelfFromDb;

            Data.Get.books.Add(viewModel.book);
			Data.Get.SaveChanges();
			return RedirectToAction("Library");
		}

		public IActionResult Books()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
