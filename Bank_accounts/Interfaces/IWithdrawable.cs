using Bank_accounts.Exceptions;

namespace Bank_accounts.Interfaces
{
    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
