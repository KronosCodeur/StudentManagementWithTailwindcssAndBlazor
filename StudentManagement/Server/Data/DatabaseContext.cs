using Microsoft.EntityFrameworkCore;
using StudentManagement.Shared.models;

namespace StudentManagement.Server.Data;

public class DatabaseContext:DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
}