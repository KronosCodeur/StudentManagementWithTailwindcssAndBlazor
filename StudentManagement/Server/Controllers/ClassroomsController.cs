using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Services;
using StudentManagement.Shared.models;

namespace ClassroomManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController:ControllerBase
{
    private readonly ClassroomsService _classroomsService;

    public ClassroomsController(ClassroomsService classroomsService)
    {
        _classroomsService = classroomsService;
    }

    [HttpGet("GetAllClassrooms")]
    public async Task<ActionResult<List<Classroom>>> GetAllClassrooms()
    {
        var classrooms = await _classroomsService.GetAllClassrooms();
        return Ok(classrooms);
    }
    [HttpGet("GetClassroomDetails/{id}")]
    public async Task<IActionResult> GetClassroomDetails(int id)
    {
        var classroom = await _classroomsService.GetClassroomDetails(id);
        if (classroom is null)
        {
            return NotFound("Classroom not found");
        }
        return Ok(classroom);
    }
    [HttpPost("SaveClassroom")]
    public async Task<ActionResult<Classroom>> SaveClassroom(Classroom classroom)
    {
        var newClassroom  = await _classroomsService.SaveClassroom(classroom);
        return CreatedAtAction(nameof(GetClassroomDetails),newClassroom,newClassroom.Id);
    }
    [HttpPut("UpdateClassroomInfo/{id}")]
    public async Task<IActionResult> UpdateClassroomInfo(int id,Classroom classroom)
    {
        var result  = await _classroomsService.UpdateClassroomInfo(id,classroom);
        if (result is null)
        {
            return NotFound("Classroom not found");
        }
        return Ok(result);
    }
    [HttpDelete("DeleteClassroom/{id}")]
    public async Task<IActionResult> DeleteClassroom(int id)
    {
        var result  = await _classroomsService.DeleteClassroom(id);
        if (!result)
        {
            return NotFound("Classroom not found");
        }
        return NoContent();
    }
}