namespace ExpenseTracker.Models.DTOs
{
    public class TokenDTO
    {
        public string? AccessToken { get; set; }
        public DateTime? Expires { get; set; }
        public string? RefreshToken { get; set; }

    }
}
