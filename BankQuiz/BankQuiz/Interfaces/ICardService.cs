using BankQuiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Interfaces
{
    public interface ICardService
    {
        public Card Login(string cardNumber, string password);
    }
}
