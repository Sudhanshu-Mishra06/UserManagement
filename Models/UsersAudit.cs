namespace UserCrudApp.Models
{
    public class UsersAudit
    {
        public int Id { get; set; }
        public string? TableName { get; set; }
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}
