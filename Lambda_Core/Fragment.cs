using Lambda_Core.Enumerators;
using Lambda_Core.Interfaces;

namespace Lambda_Core
{
    public class Fragment : IFragment
    {
        public string Name { get; set; }
        public FragmentType FragmentType { get; set; }
        public uint PressureAffection { get; set; }

        public Fragment() { }

        public Fragment(string name, FragmentType fragmentType, uint pressureAffection) 
        { 
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.FragmentType = fragmentType;
        }
    }
}
