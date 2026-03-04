using JournalApp.Models;

namespace JournalApp.Repositories;

public interface ICourseRepository
{
    IEnumerable<Course> GetAll();
    Course? Get(int id);
    void Add(Course course);
    void Update(Course course);
    void Delete(int id);
}
