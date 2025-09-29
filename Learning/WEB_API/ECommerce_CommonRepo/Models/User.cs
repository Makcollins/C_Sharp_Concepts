using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public int age { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;

    public virtual Cart? Cart { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
    public virtual Payment? Payment { get; set; }
}
public enum Gender {
    Male, Female, Trans
}
