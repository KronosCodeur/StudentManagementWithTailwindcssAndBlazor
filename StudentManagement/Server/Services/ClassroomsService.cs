using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Data;
using StudentManagement.Server.Repositories;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Services;

public class ClassroomsService : IClassroomRepository
{
    private readonly DatabaseContext _databaseContext;

    public ClassroomsService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Classroom>> GetAllClassrooms()
    {
        var classrooms = await _databaseContext.Classrooms.Include(c=>c.Students).ToListAsync();
        return classrooms;
    }

    public async Task<Classroom> SaveClassroom(Classroom classroom)
    {
        await _databaseContext.Classrooms.AddAsync(classroom);
        await _databaseContext.SaveChangesAsync();
        return classroom;
    }

    public async Task<Classroom?> GetClassroomDetails(int id)
    {
        return await _databaseContext.Classrooms.Include(classroom => classroom.Students).FirstOrDefaultAsync(classroom => classroom.Id == id);
    }

    public async Task<Classroom?> UpdateClassroomInfo(int id, Classroom classroom)
    {
        var oldClassroom = await _databaseContext.Classrooms.FirstOrDefaultAsync(c => c.Id == id);
        if (oldClassroom is null)
        {
            return null;
        }

        oldClassroom.Name = (classroom.Name == String.Empty || classroom.Name is null)
            ? oldClassroom.Name
            : classroom.Name;
        oldClassroom.Description = (classroom.Description == String.Empty || classroom.Description is null)
            ? oldClassroom.Description
            : classroom.Description;
         _databaseContext.Classrooms.Update(oldClassroom);
         await _databaseContext.SaveChangesAsync();

        return oldClassroom;
    }

    public async Task<bool> DeleteClassroom(int id)
    {
        var classroom = await _databaseContext.Classrooms.FirstOrDefaultAsync(c => c.Id == id);

        if (classroom is null)
        {
            return false;
        }
        _databaseContext.Classrooms.Remove(classroom);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}