using JournalApp.Models;
using JournalApp.Repositories;

namespace JournalApp.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repo;
    public CourseService(ICourseRepository repo) => _repo = repo;

    public IEnumerable<Course> GetAll() => _repo.GetAll();
    public Course? Get(int id) => _repo.Get(id);
    public void Create(Course course) => _repo.Add(course);
    public void Update(Course course) => _repo.Update(course);
    public void Delete(int id) => _repo.Delete(id);
}
