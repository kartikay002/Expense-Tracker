using ExpenseTracker.API.Models.Entities;
using ExpenseTracker.API.Models.DTOs;

namespace ExpenseTracker.API.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactionsAsync();

        Task<Transaction> CreateTransactionAsync(CreateTransactionRequest request);
    }
}