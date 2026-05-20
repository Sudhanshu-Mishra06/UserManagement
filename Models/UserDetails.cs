namespace UserCrudApp.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string? Account { get; set; }
        public string? Narration { get; set; }
        public string? Currency { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
