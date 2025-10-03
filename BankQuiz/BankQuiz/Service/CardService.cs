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
    public class CardService:ICardService
    {
        ICardRepository _cardRepo = new CardRepository();
        ITransactionRepository _transactionRepo = new TransactionRepository();

        public Card Login(string cardNumber, string password)
        {
            var card = _cardRepo.GetByCardNumber(cardNumber);
            if (cardNumber.Length != 16)
            {
                throw new Exception("Card number must be 16 digits!!!");
            }
            if (card == null)
                throw new Exception("Card number or password is wrong");

            if (!card.IsActive)
                throw new Exception("Card is blocked");

            if (card.Password != password)
            {
                card.FailedAttempts++;
                if (card.FailedAttempts >= 3)
                {
                    card.IsActive = false;
                }
                _cardRepo.Update(card);
                throw new Exception("Card number or password is wrong");
            }

            card.FailedAttempts = 0;
            _cardRepo.Update(card);

            return card;
        }
    }
}
