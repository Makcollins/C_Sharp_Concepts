using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketManager.Models;

namespace TicketManager.DTOs;

public class TicketsResponseDTO
{
    [Key]
    public int ticket_id { get; set; }

    [Required]
    public string title { get; set; } = null!;
    public string description { get; set; } = null!;

    [Required]
    public string? assignee { get; set; } = null!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketStatus status { get; set; }

    [Required]
    public DateTime promise_date { get; set; }
    public List<string> attachments { get; set; } = null!;
}
