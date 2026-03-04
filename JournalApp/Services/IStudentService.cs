using JournalApp.Models;

namespace JournalApp.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student? Get(int id);
    void Create(Student student);
    void Update(Student student);
    void Delete(int id);
    IEnumerable<Student> Search(string? name);
}
