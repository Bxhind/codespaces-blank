using JournalApp.Models;

namespace JournalApp.Repositories;

public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
    Student? Get(int id);
    void Add(Student student);
    void Update(Student student);
    void Delete(int id);
    IEnumerable<Student> SearchByName(string? name);
}
