using JournalApp.Models;

namespace JournalApp.Repositories;

public interface IAttendanceRepository
{
    IEnumerable<Attendance> GetByCourse(int courseId);
    IEnumerable<Attendance> GetByStudentCourse(int studentId, int courseId);
    void AddRange(IEnumerable<Attendance> items);
}
