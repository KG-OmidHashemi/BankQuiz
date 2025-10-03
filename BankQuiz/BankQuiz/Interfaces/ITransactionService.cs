using BankQuiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Interfaces
{
    public interface ITransactionService
    {
        public bool Transfer(Card sourceCard, string destinationCardNumber, float amount);

        public List<Transaction> GetTransactions(Card card);

    }
}
