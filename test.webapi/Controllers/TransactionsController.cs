using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.application.Services;
using test.domain.Models;
using test.webapi.DTOs;

namespace test.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _service;

        public TransactionsController(TransactionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionCreateDto transactionDto)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = transactionDto.Amount,
                Currency = transactionDto.Currency,
                Date = transactionDto.Date,
                Status = transactionDto.Status
            };

            await _service.AddTransactionAsync(transaction);

            var transactionReadDto = new TransactionReadDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Currency = transaction.Currency,
                Date = transaction.Date,
                Status = transaction.Status
            };

            return Ok(transactionReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(Guid id, TransactionCreateDto transactionDto)
        {
            var transaction = new Transaction
            {
                Id = id,
                Amount = transactionDto.Amount,
                Currency = transactionDto.Currency,
                Date = transactionDto.Date,
                Status = transactionDto.Status
            };

            await _service.UpdateTransactionAsync(transaction);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _service.GetTransactionByIdAsync(id);
            if (transaction == null) return NotFound();

            var transactionReadDto = new TransactionReadDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Currency = transaction.Currency,
                Date = transaction.Date,
                Status = transaction.Status
            };

            return Ok(transactionReadDto);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetTransactionsByStatus(string status)
        {
            var transactions = await _service.GetTransactionsByStatusAsync(status);

            var transactionReadDtos = new List<TransactionReadDto>();
            foreach (var transaction in transactions)
            {
                transactionReadDtos.Add(new TransactionReadDto
                {
                    Id = transaction.Id,
                    Amount = transaction.Amount,
                    Currency = transaction.Currency,
                    Date = transaction.Date,
                    Status = transaction.Status
                });
            }

            return Ok(transactionReadDtos);
        }
    }
}
