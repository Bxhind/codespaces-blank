using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models;

public class Attendance
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public bool Present { get; set; }
}
