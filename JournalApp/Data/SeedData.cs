using JournalApp.Models;

namespace JournalApp.Data;

public static class SeedData
{
    public static void EnsureSeedData(SchoolContext ctx)
    {
        ctx.Database.EnsureCreated();

        if (ctx.Students.Any()) return;

        var s1 = new Student { FirstName = "Иван", LastName = "Иванов", Email = "ivan@example.com", Group = "A1" };
        var s2 = new Student { FirstName = "Мария", LastName = "Петрова", Email = "maria@example.com", Group = "B1" };

        var c1 = new Course { Title = "Математика", Instructor = "Проф. Смирнов", Hours = 60, Credits = 4 };
        var c2 = new Course { Title = "Физика", Instructor = "Проф. Кузнецов", Hours = 45, Credits = 3 };

        c1.Students.Add(s1);
        c1.Students.Add(s2);
        c2.Students.Add(s1);

        ctx.Courses.AddRange(c1, c2);
        ctx.Students.AddRange(s1, s2);

        ctx.Attendances.Add(new Attendance { Student = s1, Course = c1, Date = DateTime.Today.AddDays(-1), Present = true });
        ctx.Attendances.Add(new Attendance { Student = s2, Course = c1, Date = DateTime.Today.AddDays(-1), Present = false });

        ctx.SaveChanges();
    }
}
