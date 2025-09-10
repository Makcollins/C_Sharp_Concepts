using System;
using System.Data;

namespace CrudPostegres;

public class BoardGame
{
    static int counter = 101;
    public string Id { get; }
    public required string Name { get; set; }
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int AverageDuration { get; set; }

    public BoardGame() { Id = $"BG{counter++}"; }
}
