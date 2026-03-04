using Microsoft.AspNetCore.Mvc;
using LibraryApp.Services;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class ReadersController : Controller
    {
        private readonly ReaderService _service;

        public ReadersController(ReaderService service)
        {
            _service = service;
        }

        public IActionResult Index()
            => View(_service.GetAll());

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            _service.Add(reader);
            TempData["Message"] = "Читатель добавлен!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult History(int id)
            => View(_service.GetHistory(id));
    }
}