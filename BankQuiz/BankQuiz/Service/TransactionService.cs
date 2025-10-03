using BankQuiz.Entities;
using BankQuiz.Interfaces;
using BankQuiz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Service
{
    public class TransactionService:ITransactionService
    {
        ICardRepository _cardRepo = new CardRepository();
        ITransactionRepository _transactionRepo = new TransactionRepository();

        public bool Transfer(Card sourceCard, string destinationCardNumber, float amount)
        {
            var destinationCard = _cardRepo.GetByCardNumber(destinationCardNumber);
            if (destinationCard == null)
            {
                throw new Exception("Destenation card was not found!");
            }

            var transaction = new Transaction
            {
                SourceCardNumber = sourceCard.CardNumber,
                DestinationCardNumber = destinationCardNumber,
                Amount = amount,
                TransactionDate = DateTime.Now,
                IsSuccessful = false
            };
            
            _transactionRepo.Add(transaction);

            if (!sourceCard.IsActive || !destinationCard.IsActive)
            {
                throw new Exception("Source or destenation card is not active!!!");
            }
            if (amount == null)
            {
                throw new Exception("Amount can not be empty!!!");
            }
            if (amount <= 0)
            {
                throw new Exception("Amount should be greater than zero!!!");
            }
            if (amount > sourceCard.Balance)
            {
                throw new Exception("Not enough balance!!!");
            }

            sourceCard.Balance -= amount;
            destinationCard.Balance += amount;

            transaction.IsSuccessful = true;
            _cardRepo.Update(sourceCard);
            _cardRepo.Update(destinationCard);

  

            return true;
        }
        public List<Transaction> GetTransactions(Card card)
        {
            return  _transactionRepo.GetByCardNumber(card.CardNumber);
        }
    }
}
