using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Repositories;
using StudentManagement.Server.Services;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase
{
    private readonly LessonService _lessonService;

    public LessonController(LessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet("GetAllLessons")]
    public async Task<ActionResult<List<Lesson>>> GetAllLessons()
    {
        var lesLessons = await _lessonService.GetAllLessons();
        return Ok(lesLessons);
    }

    [HttpPost("AddLesson")]
    public async Task<ActionResult<Lesson>> AddLeson(Lesson lesson)
    {
        var laLesson = await _lessonService.AddLesson(lesson);
        return StatusCode(201, laLesson);
    }

    [HttpPut("UpdateLesson")]
    public async Task<ActionResult<Lesson>> UpdateLesson(Lesson lesson)
    {
        var laLesson = await _lessonService.UpdateLesson(lesson);
        if (!laLesson)
            return NotFound("Lesson NotFound");
        return Ok(laLesson);
    }

    [HttpDelete("DeleteLesson")]
    public async Task<ActionResult<Lesson>> DeleteLesson(int id)
    {
        var lesson = await _lessonService.DeleteLesson(id);
        if (!lesson)
            return NotFound("Lesson NotFound");
        return Ok(lesson);
    }
}