using BankQuiz.DataAccess;
using BankQuiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Interfaces
{
    public interface ITransactionRepository
    {

        public void Add(Transaction transaction);

        public List<Transaction> GetByCardNumber(string cardNumber);

    }
}

