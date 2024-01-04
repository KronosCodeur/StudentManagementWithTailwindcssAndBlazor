using StudentManagement.Shared.models;

namespace StudentManagement.Server.Repositories;

public interface LessonRepository
{
    Task<List<Lesson>> GetAllLessons();
    Task<Lesson> AddLesson(Lesson lesson);
    Task<bool> UpdateLesson(Lesson lesson);
    Task<bool> DeleteLesson(int id);
}