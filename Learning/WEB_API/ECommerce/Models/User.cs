using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int age { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}
public enum Gender {
    Male, Female, Trans
}
