using StudentManagement.Shared.models;

namespace StudentManagement.Server.Repositories;

public interface IClassroomRepository
{
    Task<List<Classroom>> GetAllClassrooms();
    Task<Classroom> SaveClassroom(Classroom classroom);
    Task<Classroom?> GetClassroomDetails(int id);
    Task<Classroom?> UpdateClassroomInfo(int id, Classroom classroom);
    Task<bool> DeleteClassroom(int id);
}