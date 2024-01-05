using AutoMapper;
using StudentManagement.Shared.DTO;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Mapping;

public class ClassroomMapping : Profile
{
    public ClassroomMapping()
    {
        CreateMap<Classroom, ClassroomCreateDto>().ReverseMap();
    }
}