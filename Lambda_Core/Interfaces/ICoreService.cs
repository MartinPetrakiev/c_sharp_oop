namespace Lambda_Core.Interfaces
{
    public interface ICoreService
    {
        bool CreateCore(string type, int durability);
        bool RemoveCore(string name);
        bool SelectCore(string name);
    }
}
