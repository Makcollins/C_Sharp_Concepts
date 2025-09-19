using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentsAPI.Validators;

namespace StudentsAPI.Models;

public class StudentDTO
{
    [ValidateNever]
    public int Id { get; set; }

    [Required(ErrorMessage = "Student name is required")]
    [StringLength(30)]
    public string StudentName { get; set; } = String.Empty;

    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = String.Empty;

    [Required]
    public string Address { get; set; } = String.Empty;

    // [Range(10, 20)]
    // public int Age { get; set; }
    // public string Password { get; set; }

    // [Compare(nameof(Password))] 
    // public string ConfirmPassword { get; set; }
    // [DateCheck]
    // public DateTime AdmissionDate { get; set; } 
}
