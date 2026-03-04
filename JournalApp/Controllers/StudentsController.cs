using Microsoft.AspNetCore.Mvc;
using JournalApp.Services;
using JournalApp.Models;

namespace JournalApp.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentService _service;
    public StudentsController(IStudentService service) => _service = service;

    public IActionResult Index(string? q)
    {
        var list = _service.Search(q);
        return View(list);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid) return View(student);
        _service.Create(student);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var s = _service.Get(id);
        if (s == null) return NotFound();
        return View(s);
    }
}
