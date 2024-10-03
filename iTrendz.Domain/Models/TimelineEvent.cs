namespace iTrendz.Domain.Models;

public class TimelineEvent(string title, string description, DateTime timestamp, EventType type)
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime Timestamp { get; set; } = timestamp;
    public EventType Type { get; set; } = type;
}

public enum EventType
{
    Info,
    Positive,
    Negative,
    Warning,
}