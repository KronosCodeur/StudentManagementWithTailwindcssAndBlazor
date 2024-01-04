using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Data;
using StudentManagement.Server.Repositories;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Services;

public class StudentsService : IStudentsRepository
{
    private readonly DatabaseContext _databaseContext;

    public StudentsService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _databaseContext.Students.ToListAsync();
    }

    public async Task<Student> SaveStudent(Student student)
    {
        await _databaseContext.Students.AddAsync(student);
        await _databaseContext.SaveChangesAsync();
        return student;
    }

    public async Task<Student?> GetStudentDetails(int id)
    {
        var student = await _databaseContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        return student;
    }

    public async Task<Student?> UpdateStudentInfo(int id, Student student)
    {
        var oldStudent = await _databaseContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (oldStudent is null) return null;

        oldStudent.Firstname = student.Firstname == string.Empty || student.Firstname is null
            ? oldStudent.Firstname
            : student.Firstname;
        oldStudent.Lastname = student.Lastname == string.Empty || student.Lastname is null
            ? oldStudent.Lastname
            : student.Lastname;
        oldStudent.Address = student.Address == string.Empty || student.Address is null
            ? oldStudent.Address
            : student.Address;
        oldStudent.Phone = student.Phone == string.Empty || student.Phone is null
            ? oldStudent.Firstname
            : student.Phone;
        oldStudent.Age = student.Age;

        return oldStudent;
    }

    public async Task<bool> DeleteStudent(int id)
    {
        var student = await _databaseContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student is null)
        {
            return false;
        }
        _databaseContext.Students.Remove(student);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}