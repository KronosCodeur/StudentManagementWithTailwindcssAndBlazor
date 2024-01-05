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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Lesson)
            .WithMany(l => l.Teachers)
            .HasForeignKey(t=>t.IdLesson).IsRequired();
    }
}