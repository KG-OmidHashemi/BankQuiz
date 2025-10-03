using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHoldersNumber { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public int FailedAttempts { get; set; }
    }
}
