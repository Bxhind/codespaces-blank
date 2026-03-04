using Microsoft.AspNetCore.Mvc;
using JournalApp.Services;
using JournalApp.ViewModels;

namespace JournalApp.Controllers;

public class CoursesController : Controller
{
    private readonly ICourseService _service;
    private readonly IAttendanceService _attendanceService;

    public CoursesController(ICourseService service, IAttendanceService attendanceService)
    {
        _service = service;
        _attendanceService = attendanceService;
    }

    public IActionResult Index() => View(_service.GetAll());

    public IActionResult Details(int id)
    {
        var c = _service.Get(id);
        if (c == null) return NotFound();

        var attendances = _attendanceService.GetByCourse(id);
        var total = attendances.Count();
        var present = attendances.Count(a => a.Present);
        var percent = total == 0 ? 0 : (double)present / total * 100.0;

        var vm = new CourseStatsViewModel { Course = c, Students = c.Students, AttendancePercent = percent };
        return View(vm);
    }
}
