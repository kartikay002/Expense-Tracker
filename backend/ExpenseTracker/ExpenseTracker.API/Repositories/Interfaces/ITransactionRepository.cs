using ExpenseTracker.API.Models.Entities;
using ExpenseTracker.API.Models.DTOs;

namespace ExpenseTracker.API.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
            Task<List<Transaction>> GetAllTransactionsAsync();

            Task<Transaction> CreateTransactionAsync(CreateTransactionRequest request);
        }
    }