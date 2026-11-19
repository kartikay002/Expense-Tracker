using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models.DTOs
{
    public class UpdateTransactionRequest
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Range(0.01, 99999999.99)]
        public decimal Amount { get; set; }

        [Required]
        public string TransactionType { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Notes { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}