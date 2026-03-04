using JournalApp.Data;
using JournalApp.Models;

namespace JournalApp.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _ctx;
    public StudentRepository(SchoolContext ctx) => _ctx = ctx;

    public IEnumerable<Student> GetAll() => _ctx.Students.ToList();

    public Student? Get(int id) => _ctx.Students
        .Where(s => s.Id == id)
        .FirstOrDefault();

    public void Add(Student student)
    {
        _ctx.Students.Add(student);
        _ctx.SaveChanges();
    }

    public void Update(Student student)
    {
        _ctx.Students.Update(student);
        _ctx.SaveChanges();
    }

    public void Delete(int id)
    {
        var s = _ctx.Students.Find(id);
        if (s != null) { _ctx.Students.Remove(s); _ctx.SaveChanges(); }
    }

    public IEnumerable<Student> SearchByName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return GetAll();
        return _ctx.Students.Where(s => (s.FirstName + " " + s.LastName).Contains(name)).ToList();
    }
}
