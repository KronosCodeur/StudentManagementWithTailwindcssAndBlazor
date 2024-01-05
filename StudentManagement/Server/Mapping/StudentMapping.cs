using AutoMapper;
using StudentManagement.Shared.DTO;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Mapping;

public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student,StudentCreateDto>().ReverseMap();
    }
}