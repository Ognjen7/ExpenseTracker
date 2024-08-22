using ExpenseTracker.Models.Entities;

namespace ExpenseTracker.Models.DTOs;

public class MonthlyReminderDTO
{
    public string ApplicationUserId { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int DayOfMonth { get; set; }
    public ReminderType ReminderType { get; set; } = ReminderType.Monthly;
}
