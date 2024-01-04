using StudentManagement.Shared.models;

namespace StudentManagement.Server.Repositories;

public interface TeacherRepository
{
    Task<List<Teacher>> GetAllTeachers();
    Task<Teacher> AddTeacher(Teacher teacher);
    Task<bool> UpdateTeacher(int id);
    Task<bool> DeleteTeacher(int id);
}