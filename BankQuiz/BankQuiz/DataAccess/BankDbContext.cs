using BankQuiz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQuiz.DataAccess
{
    public class BankDbContext:DbContext
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankQuiz;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
