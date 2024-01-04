using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.models;

public class Classroom
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; }
}