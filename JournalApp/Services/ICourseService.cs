using JournalApp.Models;

namespace JournalApp.Services;

public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course? Get(int id);
    void Create(Course course);
    void Update(Course course);
    void Delete(int id);
}
