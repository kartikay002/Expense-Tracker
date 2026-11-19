using ExpenseTracker.API.Models.Entities;
using ExpenseTracker.API.Models.DTOs;
using ExpenseTracker.API.Repositories.Interfaces;
using ExpenseTracker.API.Services.Interfaces;

namespace ExpenseTracker.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }

        public async Task<Transaction> CreateTransactionAsync(
            CreateTransactionRequest request)
        {
            // Business validation
            if (request.TransactionType != "Income" &&
                request.TransactionType != "Expense")
            {
                throw new ArgumentException("Transaction type must be Income or Expense.");
            }

            return await _transactionRepository.CreateTransactionAsync(request);
        }
    }
}