
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ExpenseTracker.API.Models.Entities;

namespace ExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly NpgsqlDataSource _dataSource;

        public TransactionsController(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = new List<Transaction>();

            const string query = @"
                SELECT
                    transaction_id,
                    title,
                    amount,
                    transaction_type,
                    category,
                    notes,
                    transaction_date,
                    created_at
                FROM public.expense_transactions
                ORDER BY transaction_date DESC;
            ";

            await using var connection =
                await _dataSource.OpenConnectionAsync();

            await using var command =
                new NpgsqlCommand(query, connection);

            await using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var transaction = new Transaction
                {
                    TransactionId = reader.GetInt64(0),
                    Title = reader.GetString(1),
                    Amount = reader.GetDecimal(2),
                    TransactionType = reader.GetString(3),
                    Category = reader.GetString(4),

                    Notes = reader.IsDBNull(5)
                        ? null
                        : reader.GetString(5),

                    TransactionDate = reader.GetDateTime(6),
                    CreatedAt = reader.GetDateTime(7)
                };

                transactions.Add(transaction);
            }

            return Ok(transactions);
        }
    }
}
