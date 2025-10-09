using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketManager.Models;

public class Ticket
{
    [Key]
    public int ticket_id { get; }

    [Required]
    public string title { get; set; } = null!;

    public string description { get; set; } = null!;

    [Required]
    public string assignee { get; set; } = null!;

    public TicketStatus status { get; set; }

    [Required]
    public DateTime promise_date { get; set; }

    [Required]
    public List<string> attachments { get; set; } = null!;
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TicketStatus {Open, InProgress, Closed}
