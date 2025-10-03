using BankQuiz.DataAccess;
using BankQuiz.Entities;
using BankQuiz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Repositories
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly BankDbContext _db = new();
        public void Add(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            _db.SaveChanges();
        }

        public List<Transaction> GetByCardNumber(string cardNumber)
        {
            return _db.Transactions
                      .Where(t => t.SourceCardNumber == cardNumber ||
                                  t.DestinationCardNumber == cardNumber)
                      .ToList();
        }
    }
}
