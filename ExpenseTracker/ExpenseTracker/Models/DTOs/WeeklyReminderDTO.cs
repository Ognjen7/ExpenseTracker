using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Models.DTOs;

public class WeeklyReminderDTO
{
    public string ApplicationUserId { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public ReminderType ReminderType { get; set; } = ReminderType.Weekly;
}
