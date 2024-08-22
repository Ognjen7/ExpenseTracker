namespace ExpenseTracker.Models.Entities
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public ReminderType ReminderType { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
    }

    public enum ReminderType
    {
        Weekly,
        Monthly
    }
}
