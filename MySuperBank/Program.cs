using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Alena",10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}!");


            account.MakeWithdrawal(50, DateTime.Now, "coffes");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(5000, DateTime.Now, "wage");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());

            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0,2000);

            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());


            //test for negative balance
            //try
            //    {
            //        account.MakeWithdrawal(500000, DateTime.Now, "efw");
            //    }
            //    catch (InvalidOperationException e)
            //    {
            //        Console.WriteLine("Exception caught trying to overdraw");
            //        Console.WriteLine(e.ToString());
            //    }

        }
    }
}
