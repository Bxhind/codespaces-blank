using JournalApp.Models;

namespace JournalApp.ViewModels;

public class StudentDetailsViewModel
{
    public Student Student { get; set; } = null!;
    public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();
    public IEnumerable<Attendance> Attendances { get; set; } = Enumerable.Empty<Attendance>();
}
