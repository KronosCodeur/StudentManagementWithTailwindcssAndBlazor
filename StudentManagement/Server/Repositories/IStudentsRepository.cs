using StudentManagement.Shared.models;

namespace StudentManagement.Server.Repositories;

public interface IStudentsRepository
{
    Task<List<Student>> GetAllStudents();
    Task<Student> SaveStudent(Student student);
    Task<Student?> GetStudentDetails(int id);
    Task<Student?> UpdateStudentInfo(int id, Student student);
    Task<bool> DeleteStudent(int id);
}