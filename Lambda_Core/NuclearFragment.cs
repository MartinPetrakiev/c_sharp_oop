using Lambda_Core.Enumerators;

namespace Lambda_Core
{
    public class NuclearFragment : Fragment
    {
        public NuclearFragment(string name, FragmentType type, uint pressureAffection) : base(name, type, pressureAffection)
        {
            this.PressureAffection = pressureAffection * 2;
        }
    }
}
