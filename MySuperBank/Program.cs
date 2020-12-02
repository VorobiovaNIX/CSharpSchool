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
