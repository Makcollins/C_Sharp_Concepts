using System;

namespace GroupJoin;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CategoryId { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
