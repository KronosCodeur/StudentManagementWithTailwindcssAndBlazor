using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Services;
using StudentManagement.Shared.DTO;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController:ControllerBase
{
    private readonly StudentsService _studentsService;
    private readonly IMapper _mapper;
    public StudentsController(StudentsService studentsService, IMapper mapper)
    {
        _studentsService = studentsService;
        _mapper = mapper;
    }

    [HttpGet("GetAllStudents")]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        var students = await _studentsService.GetAllStudents();
        return Ok(students);
    }
    [HttpGet("GetStudentDetails/{id}")]
    public async Task<IActionResult> GetStudentDetails(int id)
    {
        var student = await _studentsService.GetStudentDetails(id);
        if (student is null)
        {
            return NotFound("Student not found");
        }
        return Ok(student);
    }
    [HttpPost("SaveStudent")]
    public async Task<ActionResult<Student>> SaveStudent(StudentCreateDto studentCreateDto)
    {
        var student = _mapper.Map<Student>(studentCreateDto);
        var newStudent  = await _studentsService.SaveStudent(student);
        return CreatedAtAction(nameof(GetStudentDetails),newStudent,newStudent.Id);
    }
    [HttpPut("UpdateStudentInfo/{id}")]
    public async Task<IActionResult> UpdateStudentInfo(int id,Student student)
    {
        var result  = await _studentsService.UpdateStudentInfo(id,student);
        if (result is null)
        {
            return NotFound("Student not found");
        }
        return Ok(result);
    }
    [HttpDelete("DeleteStudent/{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var result  = await _studentsService.DeleteStudent(id);
        if (!result)
        {
            return NotFound("Student not found");
        }
        return NoContent();
    }
}