using System;

namespace StudentsAPI.Models;

public class CollegeRepository
{
    public static List<Student> Students = new List<Student>() {
                new Student { Id = 1, StudentName = "Emmanuel", Email = "emmanuel@gmail.com", Address = "Kisumu"},
                new Student { Id = 2, StudentName = "Steve", Email = "steve@gmail.com", Address = "Kisumu"}
            };
}
