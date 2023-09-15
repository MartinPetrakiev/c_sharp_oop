using Bank_accounts.Enumerators;
using Bank_accounts.Exceptions;
using Bank_accounts.Interfaces;

namespace Bank_accounts
{
    public class DepositAccount : BankAccount, IWithdrawable
    {
        public DepositAccount(CustomerType customerType, double interestRate) : base(customerType, interestRate) {}

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

            this.Balance -= amount;
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
