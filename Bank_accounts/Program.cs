using Bank_accounts.Enumerators;

namespace Bank_accounts
{
    class Program
    {
        public static void Main(string[] args)
        {
            DepositAccount firstDepositAccount = new DepositAccount(CustommerType.Individual, 0.8);
            DepositAccount secondDepositAccount = new DepositAccount(CustommerType.Individual, 0.8);

            firstDepositAccount.Deposit((decimal)1000.24);
            secondDepositAccount.Deposit((decimal)846.434);

            Console.WriteLine($"First deposit account interest amount: {firstDepositAccount.CalculateInterestAmount(5):F2}");
            Console.WriteLine($"Second deposit account interest amount: {secondDepositAccount.CalculateInterestAmount(13):F2}");
        }
    }
}
