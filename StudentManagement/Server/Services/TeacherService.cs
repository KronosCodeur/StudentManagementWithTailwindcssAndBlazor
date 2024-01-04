using StudentManagement.Server.Repositories;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Services;

public class TeacherService : TeacherRepository
{
    public async Task<List<Teacher>> GetAllTeachers()
    {
        throw new NotImplementedException();
    }

    public async Task<Teacher> AddTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteTeacher(int id)
    {
        throw new NotImplementedException();
    }
}