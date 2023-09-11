using Bank_accounts.Enumerators;

namespace Bank_accounts
{
    public class LoanAccount : BankAccount
    {
        public LoanAccount(CustommerType custommerType, double interestRate) : base(custommerType, interestRate)
        {
        }

        public void DepositMoney(decimal amount)
        {
            this.balance += amount;
        }

        public override decimal CalculateInterestAmount(int periodOfTime)
        {
            decimal interestAmount = 0;
            switch (this.CustommerType)
            {
                case CustommerType.Individual:
                    if (periodOfTime > 3)
                    {
                        interestAmount = this.Balance * (decimal)(Math.Pow(1 + this.InterestRate, periodOfTime - 3) - 1); ;
                    }
                    break;

                case CustommerType.Company:
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
