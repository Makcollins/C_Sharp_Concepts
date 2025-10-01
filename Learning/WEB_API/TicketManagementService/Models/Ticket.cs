using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TicketManagementService.Models;

public class Ticket
{
    [Key]
    public int ticket_id { get; }
    [Required]
    public string title { get; set; } = null!;
    public string description { get; set; } = null!;
    [Required]
    public string assignee { get; set; } = null!;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketStatus status { get; set; }
    [Required]
    public DateTime promise_date { get; set; }
    [Required]
    public List<string> attachments { get; set; } = null!;
    
}
public enum TicketStatus {Open, InProgress, Closed}