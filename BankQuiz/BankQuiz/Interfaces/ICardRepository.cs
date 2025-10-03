using BankQuiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Interfaces
{
    public interface ICardRepository
    {
        public bool Add(Card card);


        public Card GetByCardNumber(string cardNumber);

        public void Update(Card card);

    }
}
