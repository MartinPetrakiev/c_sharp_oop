using Bank_accounts.Enumerators;
using Bank_accounts.Interfaces;

namespace Bank_accounts
{
    public class MortgageAccount : BankAccount
    {
        public MortgageAccount(CustomerType custommerType, double interestRate) : base(custommerType, interestRate) {}

        public override decimal CalculateInterestAmount(int periodOfTime)
        {
            decimal interestAmount = 0;
            switch (this.CustomerType)
            {
                case CustomerType.Individual:
                    if (periodOfTime > 6)
                    {
                        interestAmount = this.Balance * (decimal)(this.InterestRate / 100) * (periodOfTime - 6);
                    }
                    break;

                case CustomerType.Company:
                    if (periodOfTime <= 12)
                    {
                        interestAmount = this.Balance * (decimal)(this.InterestRate / 100) * periodOfTime;
                    }
                    else
                    {
                        decimal firstTwelveMonths = this.Balance * (decimal)(this.InterestRate / 100) / 2 * 12;
                        interestAmount = firstTwelveMonths + this.Balance * (decimal)(this.InterestRate / 100) * (periodOfTime - 12);
                    }
                    break;
            }

            return interestAmount;
        }
    }
}
