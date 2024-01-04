using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Services;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController:ControllerBase
{
    private readonly StudentsService _studentsService;

    public StudentsController(StudentsService studentsService)
    {
        _studentsService = studentsService;
    }

    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        var students = await _studentsService.GetAllStudents();
        return Ok(students);
    }
}