using JournalApp.Models;

namespace JournalApp.Services;

public interface IAttendanceService
{
    IEnumerable<Attendance> GetByCourse(int courseId);
    IEnumerable<Attendance> GetByStudentCourse(int studentId, int courseId);
    void Record(IEnumerable<Attendance> items);
}
