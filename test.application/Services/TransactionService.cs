using test.domain.Interfaces;
using test.domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.application.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task AddTransactionAsync(Transaction transaction) => _repository.AddAsync(transaction);
        public Task UpdateTransactionAsync(Transaction transaction) => _repository.UpdateAsync(transaction);
        public Task<Transaction> GetTransactionByIdAsync(Guid id) => _repository.GetByIdAsync(id);
        public Task<IEnumerable<Transaction>> GetTransactionsByStatusAsync(string status) => _repository.GetByStatusAsync(status);
    }
}
