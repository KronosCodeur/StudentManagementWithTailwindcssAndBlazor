namespace StudentManagement.Shared.DTO;

public class StudentCreateDto
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int ClassroomId { get; set; }
}