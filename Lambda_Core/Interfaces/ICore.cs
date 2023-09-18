using Lambda_Core.Enumerators;

namespace Lambda_Core.Interfaces
{
    public interface ICore
    {
        char CoreID { get; set; }
        CoreType CoreType { get; set; }
        uint Durability { get; set; }
    }
}
