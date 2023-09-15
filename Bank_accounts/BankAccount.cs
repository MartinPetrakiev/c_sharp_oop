using Bank_accounts.Enumerators;
using Bank_accounts.Interfaces;

namespace Bank_accounts
{
    public abstract class BankAccount : IAccount, IDepositable
    {
        protected CustomerType customerType;
        protected double interestRate;
        protected decimal balance;

        public BankAccount(CustomerType customerType, double interestRate) 
        {
            this.CustomerType = customerType;
            this.InterestRate = interestRate;
        }

        public CustomerType CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }

        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
            }
            else
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
        }

        public abstract decimal CalculateInterestAmount(int periodOfTime);
    }
}
