using System;

//Abstração criando nova classe para essa conta
namespace Classes
{
    //Herdando a classe BankAccount
    class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        //Polimorfismo
        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.02m; 
                MakeDeposit(interest, DateTime.Now,"Apply monthly interest");
            }
        }
    }
}