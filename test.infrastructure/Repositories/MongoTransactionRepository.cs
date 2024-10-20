﻿using MongoDB.Driver;
using test.domain.Interfaces;
using test.domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.infrastructure.Repositories
{
    public class MongoTransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Transaction> _collection;

        public MongoTransactionRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("isalud-multiradicador-pre-ips");
            _collection = database.GetCollection<Transaction>("transacciones");
        }


        public async Task AddAsync(Transaction transaction) => await _collection.InsertOneAsync(transaction);
        public async Task UpdateAsync(Transaction transaction) => await _collection.ReplaceOneAsync(t => t.Id == transaction.Id, transaction);
        public async Task<Transaction> GetByIdAsync(Guid id) => await _collection.Find(t => t.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Transaction>> GetByStatusAsync(string status) => await _collection.Find(t => t.Status == status).ToListAsync();
    }
}
