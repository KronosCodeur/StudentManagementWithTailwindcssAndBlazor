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
    public DbSet<Classroom> Classrooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasOne<Classroom>(s => s.Classroom).WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassroomId).IsRequired();
    }
}