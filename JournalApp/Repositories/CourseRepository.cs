using JournalApp.Data;
using JournalApp.Models;

namespace JournalApp.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly SchoolContext _ctx;
    public CourseRepository(SchoolContext ctx) => _ctx = ctx;

    public IEnumerable<Course> GetAll() => _ctx.Courses.ToList();

    public Course? Get(int id) => _ctx.Courses.Find(id);

    public void Add(Course course)
    {
        _ctx.Courses.Add(course);
        _ctx.SaveChanges();
    }

    public void Update(Course course)
    {
        _ctx.Courses.Update(course);
        _ctx.SaveChanges();
    }

    public void Delete(int id)
    {
        var c = _ctx.Courses.Find(id);
        if (c != null) { _ctx.Courses.Remove(c); _ctx.SaveChanges(); }
    }
}
