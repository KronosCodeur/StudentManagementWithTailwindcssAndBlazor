using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.models;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    
    public int IdLesson { get; set; }
    public Lesson Lesson { get; set; }
}