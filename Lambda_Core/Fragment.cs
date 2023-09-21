using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public class Fragment
    {
        public string Name { get; set; }
        public FragmentType FragmentType { get; protected set; }
        public uint PressureAffection { get; protected set; }

        protected Fragment(string name, FragmentType type, uint pressureAffection)
        {
            this.Name = name;
            this.FragmentType = type;
            this.PressureAffection = pressureAffection;
        }
    }
}
