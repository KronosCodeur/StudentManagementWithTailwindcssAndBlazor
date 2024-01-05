using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Repositories;
using StudentManagement.Server.Services;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly TeacherService _teacherService;

    public TeacherController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("GetAllTeacher")]
    public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
    {
        var lesteachers = await _teacherService.GetAllTeachers();
        return Ok(lesteachers);
    }

    [HttpPost("AddTeacher")]
    public async Task<ActionResult<Teacher>> AddTeacher(Teacher teacher)
    {
        var leTeacher = await _teacherService.AddTeacher(teacher);
        if (leTeacher == null)
            return BadRequest("Tray again");
        return StatusCode(201, leTeacher);
    }

    [HttpPut("UpdateTeacher/{id}")]
    public async Task<ActionResult<Teacher>> UpdateTeacher(Teacher teacher)
    {
        var existingTeacher = await _teacherService.UpdateTeacher(teacher);
        if (!existingTeacher)
            return NotFound("Teacher notFound");
        return Ok(existingTeacher);
    }

    [HttpDelete("DeleteTeacher")]
    public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
    {
        var teacher = await _teacherService.DeleteTeacher(id);
        if (teacher)
            return NotFound("Teacher notFounf");
        return Ok(teacher);
    }
    


}