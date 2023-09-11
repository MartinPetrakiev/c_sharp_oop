using Bank_accounts.Enumerators;

namespace Bank_accounts
{
    public class MortgageAccount : BankAccount
    {
        public MortgageAccount(CustommerType custommerType, double interestRate) : base(custommerType, interestRate)
        {
        }

        public void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public override decimal CalculateInterestAmount(int periodOfTime)
        {
            decimal interestAmount = 0;
            switch (this.CustommerType)
            {
                case CustommerType.Individual:
                    if (periodOfTime > 6)
                    {
                        interestAmount = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate, periodOfTime - 6) - 1); ;
                    }
                    break;

                case CustommerType.Company:
                    if (periodOfTime <= 12)
                    {
                        interestAmount = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate / 2, periodOfTime) - 1);
                    }
                    else
                    {
                        decimal firstTwelveMonths = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate / 2, 12) - 1);
                        interestAmount = firstTwelveMonths + this.Balance * (decimal)(Math.Pow(1 + this.InterestRate, periodOfTime - 12) - 1);
                    }
                    break;
            }

            return interestAmount;
        }
    }
}
