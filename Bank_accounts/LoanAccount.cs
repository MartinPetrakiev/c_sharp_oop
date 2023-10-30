using Bank_accounts.Enumerators;
using Bank_accounts.Interfaces;

namespace Bank_accounts
{
    public class LoanAccount : BankAccount
    {
        public LoanAccount(CustomerType custommerType, double interestRate) : base(custommerType, interestRate) {}

        public override decimal CalculateInterestAmount(int periodOfTime)
        {
            decimal interestAmount = 0;
            switch (this.CustomerType)
            {
                case CustomerType.Individual:
                    if (periodOfTime > 3)
                    {
                        interestAmount = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate, periodOfTime - 3) - 1); ;
                    }
                    break;

                case CustomerType.Company:
                    if (periodOfTime > 2)
                    {
                        interestAmount = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate, periodOfTime - 2) - 1); ;
                    }
                    break;
            }

            return interestAmount;
        }
    }
}
