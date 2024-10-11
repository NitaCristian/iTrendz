namespace iTrendz.Domain.Models;

public class ActionLog
{
    public int Id { get; set; }
    public Campaign Campaign { get; set; }
    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTime Timestamp { get; set; }

    public ActionType Type { get; set; }

    public ActionLog(string title, string description, DateTime timestamp, ActionType type)
    {
        Title = title;
        Description = description;
        Timestamp = timestamp;
        Type = type;
    }
}