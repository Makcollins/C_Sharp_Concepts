using System;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce;

public class User
{
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int age { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}
public enum Gender {
    Male, Female, Trans
}
