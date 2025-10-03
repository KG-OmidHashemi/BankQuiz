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
    public class CardRepository:ICardRepository
    {
        private readonly BankDbContext _db = new();
        public bool Add(Card card)
        {
            _db.Cards.Add(card);
            _db.SaveChanges();
            return true;
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _db.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void Update(Card card)
        {
            _db.Cards.Update(card);
            _db.SaveChanges();
        }
    }
}
