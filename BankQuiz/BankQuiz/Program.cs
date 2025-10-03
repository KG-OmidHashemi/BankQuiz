using BankQuiz.Entities;
using BankQuiz.Service;

CardService cardService = new CardService();
TransactionService transactionService= new TransactionService();
Card LoggedInCard = null;


while (true)
{
    try
    {
        Console.WriteLine("Enter the Card Number:");
        string cardNumber = Console.ReadLine();
        Console.WriteLine("Enter the password:");
        string password = Console.ReadLine();
        LoggedInCard = cardService.Login(cardNumber, password);
        menu(LoggedInCard);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


void menu(Card card)
{
    bool isLoggedIn = true;
    while (isLoggedIn)
    {
        Console.Clear();
        Console.WriteLine("Welcome!!!");
        Console.WriteLine("1.Transfer");
        Console.WriteLine("2.View Transactions");
        Console.WriteLine("3.Exit");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                try
                {
                    Console.WriteLine($"Your Card Number:{card.CardNumber}");
                    Console.WriteLine("Enter destenation card number:");
                    string? destenationCardNumber = Console.ReadLine();
                    Console.WriteLine("Enter the amount:");
                    float amount = float.Parse(Console.ReadLine());
                    transactionService.Transfer(card, destenationCardNumber, amount);
                    Console.WriteLine("Transfer was successful");
                    Console.ReadKey();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                break;

            case "2":
                Console.Clear();
                var transactions = transactionService.GetTransactions(card);
                Console.WriteLine($"Your card number:{card.CardNumber}");
                Console.WriteLine("|   Source card Number   | Destenation card Number |    Transaction Date   |  Amount  | Succesful |");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"|    {transaction.SourceCardNumber}    |     {transaction.DestinationCardNumber}    | {transaction.TransactionDate} |   {transaction.Amount}    | {transaction.IsSuccessful} |");
                }
                Console.ReadKey();
                break;
            case "3":
                isLoggedIn = false;
                break;
        }
    }

}
