using Microsoft.AspNetCore.Mvc;
using JournalApp.Services;

namespace JournalApp.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IStudentService _studentService;
    private readonly IAttendanceService _attendanceService;

    public ApiController(ICourseService courseService, IStudentService studentService, IAttendanceService attendanceService)
    {
        _courseService = courseService;
        _studentService = studentService;
        _attendanceService = attendanceService;
    }

    [HttpGet("courses/{id}/attendance")]
    public IActionResult CourseAttendance(int id)
    {
        var course = _courseService.Get(id);
        if (course == null) return NotFound();
        var attendances = _attendanceService.GetByCourse(id);
        var total = attendances.Count();
        var present = attendances.Count(a => a.Present);
        return Ok(new { Course = course.Title, Total = total, Present = present, Percent = total == 0 ? 0 : (double)present / total * 100 });
    }

    [HttpGet("students/search")]
    public IActionResult SearchStudents([FromQuery] string? name)
    {
        var found = _studentService.Search(name).Select(s => new { s.Id, s.FirstName, s.LastName, s.Email, s.Group });
        return Ok(found);
    }
}
