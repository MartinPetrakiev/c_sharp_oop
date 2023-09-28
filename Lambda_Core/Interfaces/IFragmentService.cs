namespace Lambda_Core.Interfaces
{
    public interface IFragmentService
    {
        bool AttachFragment(string type, string name, int pressureAffection);
        bool DetachFragment(Core core);
    }

}
