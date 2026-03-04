using JournalApp.Models;

namespace JournalApp.ViewModels;

public class CourseStatsViewModel
{
    public Course Course { get; set; } = null!;
    public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();
    public double AttendancePercent { get; set; }
}
