using System;
using System.Data;

namespace CrudPostegres;

public class BoardGame
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int AverageDuration { get; set; }
}
