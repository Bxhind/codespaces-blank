using JournalApp.Models;
using JournalApp.Repositories;

namespace JournalApp.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repo;
    public AttendanceService(IAttendanceRepository repo) => _repo = repo;

    public IEnumerable<Attendance> GetByCourse(int courseId) => _repo.GetByCourse(courseId);
    public IEnumerable<Attendance> GetByStudentCourse(int studentId, int courseId) => _repo.GetByStudentCourse(studentId, courseId);
    public void Record(IEnumerable<Attendance> items) => _repo.AddRange(items);
}
