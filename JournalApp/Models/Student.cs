using System.ComponentModel.DataAnnotations;

namespace JournalApp.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    public string? Group { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
