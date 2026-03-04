using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? Instructor { get; set; }

    public int Hours { get; set; }

    public int Credits { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
