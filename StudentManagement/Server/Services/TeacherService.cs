using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Data;
using StudentManagement.Server.Repositories;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Services;

public class TeacherService : TeacherRepository
{
    private readonly DatabaseContext _dbcontext;

    public TeacherService(DatabaseContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task<List<Teacher>> GetAllTeachers()
    {
        var teachers = await _dbcontext.Teachers.ToListAsync();
        return teachers;
    }

    public async Task<Teacher> AddTeacher(Teacher teacher)
    {
        var leTeacher = await _dbcontext.Teachers.AddAsync(teacher);
        await _dbcontext.SaveChangesAsync();
        return leTeacher.Entity;
    }

    public async Task<bool> UpdateTeacher(Teacher teacher)
    {
        var existingTeacher = await _dbcontext.Teachers.Where(t => t.Id == teacher.Id).FirstOrDefaultAsync();
        if (existingTeacher == null)
        {
            return false;
        }

        var firstName = teacher.Firstname;
        if (string.IsNullOrEmpty(firstName))
        {
            existingTeacher.Firstname = existingTeacher.Firstname;
        }
        else
        {
            existingTeacher.Firstname = teacher.Firstname;
        }

        var lastName = teacher.Lastname;
        if (string.IsNullOrEmpty(lastName))
        {
            existingTeacher.Lastname = existingTeacher.Lastname;
        }
        else
        {
            existingTeacher.Lastname = teacher.Lastname;
        }

        var address = teacher.Address;
        if (string.IsNullOrEmpty(address))
        {
            existingTeacher.Address = existingTeacher.Address;
        }
        else
        {
            existingTeacher.Address = teacher.Address;
        }

        var phone = teacher.Phone;
        if (string.IsNullOrEmpty(phone))
        {
            existingTeacher.Phone = existingTeacher.Phone;
        }
        else
        {
            existingTeacher.Phone = teacher.Phone;
        }

        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTeacher(int id)
    {
        var teacher = await _dbcontext.Teachers.Where(t => t.Id == id).FirstOrDefaultAsync();
        if (teacher is null)
            return false;
        _dbcontext.Teachers.Remove(teacher);
        await _dbcontext.SaveChangesAsync();
        return true;
    }
}