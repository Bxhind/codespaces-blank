using JournalApp.Models;
using JournalApp.Repositories;

namespace JournalApp.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;
    public StudentService(IStudentRepository repo) => _repo = repo;

    public IEnumerable<Student> GetAll() => _repo.GetAll();
    public Student? Get(int id) => _repo.Get(id);
    public void Create(Student student) => _repo.Add(student);
    public void Update(Student student) => _repo.Update(student);
    public void Delete(int id) => _repo.Delete(id);
    public IEnumerable<Student> Search(string? name) => _repo.SearchByName(name);
}
