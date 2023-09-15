using Bank_accounts.Enumerators;

namespace Bank_accounts.Interfaces
{
    public interface IAccount
    {
        CustomerType CustomerType { get; set; }

        double InterestRate { get; set; }

        decimal Balance
        {
            get { return this.Balance; }
            protected set { this.Balance = value; }
        }

        decimal CalculateInterestAmount(int periodOfTime);
    }
}
