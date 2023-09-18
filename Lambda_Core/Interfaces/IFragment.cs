using Lambda_Core.Enumerators;

namespace Lambda_Core.Interfaces
{
    public interface IFragment
    {
        string Name { get; set; }
        public FragmentType FragmentType { get; set; }
        public uint PressureAffection { get; set; }
    }
}
