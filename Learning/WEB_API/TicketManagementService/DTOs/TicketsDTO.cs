using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TicketManagementService.Models;

namespace TicketManagementService.DTOs;

public class TicketsDTO
{
    [Required]
    public string title { get; set; } = null!;

    public string description { get; set; } = null!;

    [Required]
    public string assignee { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketStatus status { get; set; }

    [Required]
    public DateTime promise_date { get; set; }
    
    public List<IFormFile> attachments { get; set; } = null!;
}
