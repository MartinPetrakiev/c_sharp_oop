using Bank_accounts.Enumerators;

namespace Bank_accounts
{
    public abstract class BankAccount
    {
        protected CustommerType custommerType;
        protected double interestRate;
        protected decimal balance;

        public BankAccount(CustommerType custommerType, double interestRate) 
        {
            this.custommerType = custommerType;
            this.interestRate = interestRate;
        }

        public CustommerType CustommerType
        {
            get { return custommerType; }
        }

        public double InterestRate
        {
            get { return interestRate; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public abstract decimal CalculateInterestAmount(int periodOfTime);
    }
}
