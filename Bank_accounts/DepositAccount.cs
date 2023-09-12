using Bank_accounts.Enumerators;
using Bank_accounts.Exceptions;

namespace Bank_accounts
{
    public class DepositAccount : BankAccount
    {
        public DepositAccount(CustommerType custommerType, double interestRate) : base(custommerType, interestRate)
        {
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > this.Balance)
            {
                throw new InsufficientFundsException("Insufficient funds to make the withdrawal.");
            }

            this.balance -= amount;
        }

        public override decimal CalculateInterestAmount(int periodOfTime)
        {
            decimal interestAmount = 0;
            if (this.Balance >= 1000) 
            {
                Console.WriteLine(this.Balance);
                interestAmount = this.Balance * (decimal)(this.InterestRate / 100) * periodOfTime;
            }

            return interestAmount;
        }
    }
}
