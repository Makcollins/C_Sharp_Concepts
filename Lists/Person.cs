using System;

namespace Lists;

public class Person
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public double Weight { get; set; }

}

public enum Gender{Male,Female}
