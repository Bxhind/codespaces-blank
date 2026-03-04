using Microsoft.AspNetCore.Mvc;
using LibraryApp.Services;
using LibraryApp.Data;

namespace LibraryApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly LoanService _service;
        private readonly LibraryContext _context;

        public LoansController(LoanService service, LibraryContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Books = _context.Books.ToList();
            ViewBag.Readers = _context.Readers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(int bookId, int readerId)
        {
            try
            {
                _service.Borrow(bookId, readerId);
                TempData["Message"] = "Книга выдана!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }

            return RedirectToAction("Active");
        }

        public IActionResult Return(int id)
        {
            _service.Return(id);
            TempData["Message"] = "Книга возвращена!";
            return RedirectToAction("Active");
        }

        public IActionResult Active()
            => View(_service.GetActive());
    }
}