using JournalApp.Data;
using JournalApp.Models;

namespace JournalApp.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly SchoolContext _ctx;
    public AttendanceRepository(SchoolContext ctx) => _ctx = ctx;

    public IEnumerable<Attendance> GetByCourse(int courseId) => _ctx.Attendances.Where(a => a.CourseId == courseId).ToList();

    public IEnumerable<Attendance> GetByStudentCourse(int studentId, int courseId) =>
        _ctx.Attendances.Where(a => a.StudentId == studentId && a.CourseId == courseId).ToList();

    public void AddRange(IEnumerable<Attendance> items)
    {
        _ctx.Attendances.AddRange(items);
        _ctx.SaveChanges();
    }
}
