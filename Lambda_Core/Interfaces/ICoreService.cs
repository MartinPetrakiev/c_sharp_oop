namespace Lambda_Core.Interfaces
{
    public interface ICoreService
    {
        bool AddFragment(Core core, Fragment fragment);
        string IsCritical(Core core);
        string ToString(Core core);
    }
}
