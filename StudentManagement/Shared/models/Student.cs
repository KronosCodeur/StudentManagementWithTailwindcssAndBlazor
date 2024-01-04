using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public int age { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}