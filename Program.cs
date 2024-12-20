﻿using System;
using Classes;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {   
            //teste operações basicas
            var account = new BankAccount("Leandro", 5000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeDeposit(1000, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);

            account.MakeWithdrawal(1500, DateTime.Now, "Payment car crash");
            Console.WriteLine(account.Balance);


            //Teste que a conta deve ser criada com saldo positivo
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caugth creating account whit negative balance");
                Console.WriteLine(e.ToString());
                return;
            } 

            //teste fazer saque sem saldo
            try
            {
                account.MakeWithdrawal(700, DateTime.Now, "Attemp to overdraw");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Exception caugth trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());

            //Teste cartão presente
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory()); 

            Console.WriteLine(giftCard.Balance);

            //Teste Rendimento
            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            Console.WriteLine(savings.Balance); 

            //Teste Crédito
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

            Console.WriteLine(lineOfCredit.Balance);
        }
    }
}