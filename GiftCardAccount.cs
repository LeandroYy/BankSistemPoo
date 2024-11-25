using System;

//Abstração criando nova classe para essa conta
namespace Classes
{
    //Herdando a classe BankAccount
    class GiftCardAccount : BankAccount
    {
        //Encapsulando
       private readonly decimal _monthlyDeposit = 0;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        {
            _monthlyDeposit = monthlyDeposit;
        }
        
        //Polimorfismo
        public override void PerformMonthEndTransactions()
        {
            if(_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add mouthly deposit");
            }
        }
    }
}