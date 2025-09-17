using System;

namespace StudentsAPI.Models;

public class Student
{
    public int Id { get; set; }
    public string StudentName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
}