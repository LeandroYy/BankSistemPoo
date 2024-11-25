using System;

//Abstração criando nova classe para essa conta
namespace Classes
{   
    //Herdando a classe BankAccount
    class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        //Polimorfismo
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        //Polimorfismo
        protected override Transaction? CheckWithdrawalLimit(bool isOverDrawn) =>
        isOverDrawn
        ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
        : default;

    }
}