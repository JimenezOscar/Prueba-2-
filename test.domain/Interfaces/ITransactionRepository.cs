using test.domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetByStatusAsync(string status);
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
