using Microsoft.AspNetCore.Mvc;
using LibraryApp.Services;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        public IActionResult Index()
            => View(_service.GetAll());

        public IActionResult Create()
            => View();

        public IActionResult Edit(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _service.Update(book);
            TempData["Message"] = "Книга обновлена!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _service.Add(book);
            TempData["Message"] = "Книга добавлена!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            TempData["Message"] = "Книга удалена!";
            return RedirectToAction("Index");
        }

        public IActionResult ByAuthor(string author)
            => View("Index", _service.GetByAuthor(author));

        public IActionResult GetBooksJson()
            => Json(_service.GetAll());
    }
}