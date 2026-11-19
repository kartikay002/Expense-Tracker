namespace ExpenseTracker.API.Models.Entities
{
    public class Transaction
    {
        public long TransactionId { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
