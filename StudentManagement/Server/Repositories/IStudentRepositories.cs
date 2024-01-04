using StudentManagement.Shared.models;

namespace StudentManagement.Server.Repositories;

public interface IStudentRepositories
{
    Task<List<Student>> GetAllStudents();
    Task<Student> SaveStudent(Student student);
    Task<Student?> GetStudentDetails(int id);
    Task<Student?> UpdateStudentInfo(int id, Student student);
    void DeleteStudent(int id);
}