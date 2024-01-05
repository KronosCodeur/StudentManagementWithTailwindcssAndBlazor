using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Data;
using StudentManagement.Server.Repositories;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Services;

public class LessonService : LessonRepository
{
    private readonly DatabaseContext _dbContext;

    public LessonService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Lesson>> GetAllLessons()
    {
        var lesLessons = await _dbContext.Lessons.ToListAsync();
        return lesLessons;
    }

    public async Task<Lesson> AddLesson(Lesson lesson)
    {
        var laLesson = await _dbContext.Lessons.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();
        return laLesson.Entity;
    }

    public async Task<bool> UpdateLesson(Lesson lesson)
    {
        var existingLesson = await _dbContext.Lessons.Where(l => l.Id == lesson.Id).FirstOrDefaultAsync();
        if (existingLesson == null)
            return false;

        var name = lesson.Name;
        if (string.IsNullOrEmpty(name))
            existingLesson.Name = existingLesson.Name;
        else
            existingLesson.Name = lesson.Name;

        var description = lesson.Description;
        if (string.IsNullOrEmpty(description))
            existingLesson.Description = existingLesson.Description;
        else
            existingLesson.Description = lesson.Description;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteLesson(int id)
    {
        var laLesson = await _dbContext.Lessons.Where(l => l.Id == id).FirstOrDefaultAsync();
        if (laLesson == null)
            return false;
        _dbContext.Remove(laLesson);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}